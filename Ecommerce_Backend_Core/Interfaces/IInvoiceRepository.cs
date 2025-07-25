
using Ecommerce_Backend_Core.Shared;

namespace Ecommerce_Backend_Core.Interfaces
{
    public interface IInvoiceRepository
    {
        public Task<ApiResponse> CreateInvoiceAsync(int customerId);
        public Task<ApiResponse> GetInvoiceReceipt(int customerId, int invoiceId);
    }
}
