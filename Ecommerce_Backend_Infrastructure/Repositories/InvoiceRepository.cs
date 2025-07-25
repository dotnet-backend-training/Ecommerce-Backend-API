using Ecommerce_Backend_Core.Interfaces;
using Ecommerce_Backend_Core.Models;
using Ecommerce_Backend_Core.Shared;
using Ecommerce_Backend_Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Ecommerce_Backend_Infrastructure.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvoiceRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        public async Task<ApiResponse> CreateInvoiceAsync(int customerId)
        {
            var cartItems = await _appDbContext.ShoppingCartItems
                .Include(shoppingCartItem => shoppingCartItem.Item)
                .Where(shoppingCartItem => shoppingCartItem.CustomerId == customerId)
                .ToListAsync();
           if(cartItems is null)
            {
                return FailResponse.CreateWithError(
                    message: "Failed to create ionvoice",
                    error: "shopping cart not found!",
                    statusCode: HttpStatusCode.NotFound
                );
            }
            if (cartItems.Count < 1)
            {
                return FailResponse.CreateWithError(
                       message: "Failed to create invoice",
                       error: "Cart is empty. Cannot create invoice.",
                       statusCode: HttpStatusCode.BadRequest
                );
            }
            var invoice = new Invoice { 
                CustomerId = customerId,
                CreatedAt = DateTime.UtcNow,
                NetPrice = 0, 
                TransactionType = 1,
                PaymentType = 1,
                IsPosted = true,
                IsClosed = false,
                IsReviewed = false,
            };
            await _appDbContext.Invoices.AddAsync(invoice);
            await _appDbContext.SaveChangesAsync();

            var unavailableItems = new List<string>();
            double totalNetPrice = 0;
            foreach (var cartItem in cartItems)
            {
                var itemStore = await _appDbContext.InventoryItems.FirstOrDefaultAsync(
                    inventoryItem => 
                    inventoryItem.ItemId == cartItem.ItemId 
                    && inventoryItem.StoreId == cartItem.StoreId
                );
                if( itemStore is null)
                {
                    unavailableItems.Add(cartItem.Item.Name);
                    continue;
                }
                var availableQuantity = itemStore.Balance - itemStore.ReservedQuantity;
                if(cartItem.Quantity > availableQuantity)
                {
                    unavailableItems.Add(cartItem.Item.Name);
                    continue;
                }
                var unitPrice = cartItem.Item.Price;
                var itemTotalPrice = (cartItem.Quantity * unitPrice);
                totalNetPrice += itemTotalPrice;
                var invoiceDetails = new InvoiceDetails { 
                    InvoiceId = invoice.Id,
                    ItemId = cartItem.ItemId,
                    Quantity = (int) cartItem.Quantity,
                    Factor = 1,
                    Price = (int) unitPrice,
                    UnitId = cartItem.UnitId,
                    CreatedAt = DateTime.UtcNow,
                };
                await _appDbContext.InvoicesDetails.AddAsync(invoiceDetails);
                itemStore.ReservedQuantity += cartItem.Quantity;
                _appDbContext.InventoryItems.Update(itemStore);
                await _appDbContext.SaveChangesAsync();
            }
            invoice.NetPrice = totalNetPrice;
            _appDbContext.ShoppingCartItems.RemoveRange(
                cartItems.Where(cartItem => !unavailableItems.Contains(cartItem.Item.Name))
            );
            await _appDbContext.SaveChangesAsync();
            if(unavailableItems.Count > 0)
            {
                var unavailableItemMessage = string.Join(", ",
                    unavailableItems.Select(unavailableItemName =>
                    {
                        var cartItem = cartItems.FirstOrDefault(cartItem =>
                        cartItem.Item.Name == unavailableItemName
                        );
                        if(cartItem is not null)
                        {
                            var itemStore = _appDbContext.InventoryItems.FirstOrDefault(
                              inventoryItem => inventoryItem.ItemId == cartItem.ItemId
                            );
                            if (itemStore is not null)
                            {
                                double availableQuantity = itemStore.Balance - itemStore.ReservedQuantity;
                                return $"{unavailableItemName}: (Available Quantity = {availableQuantity}";
                            }
                          
                        }
                        return unavailableItemName;
                    }));
                return FailResponse.CreateWithError(
                    statusCode: HttpStatusCode.BadRequest,
                    message: "Failed to create invoice",
                    error: string.Join(", ", unavailableItemMessage)
                );
            }
            return SuccessResponse.Create(
                statusCode: HttpStatusCode.Created,
                message: $"Invoice created successfully with id: {invoice.Id} and " +
                $"total price: {invoice.NetPrice}"
            );
        }

        public Task<ApiResponse> GetInvoiceReceipt(int customerId, int invoiceId)
        {
            throw new NotImplementedException();
        }
    }
}
