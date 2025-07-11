using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce_Backend_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Tablesdataseeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classifications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics & Gadgets" },
                    { 2, "Health & Wellness" },
                    { 3, "Automotive Parts" },
                    { 4, "Sports Equipment" },
                    { 5, "Beauty & Personal Care" }
                });

            migrationBuilder.InsertData(
                table: "Governments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Egypt" },
                    { 2, "Palestine" },
                    { 3, "Jordan" },
                    { 4, "Lebanon" },
                    { 5, "Syria" }
                });

            migrationBuilder.InsertData(
                table: "MainGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Clothing" },
                    { 3, "Home & Kitchen" },
                    { 4, "Sports & Outdoors" },
                    { 5, "Beauty & Personal Care" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Piece" },
                    { 2, "Kilogram" },
                    { 3, "Liter" },
                    { 4, "Box" },
                    { 5, "Pack" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "GovernmentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Cairo" },
                    { 2, 1, "Alexandria" },
                    { 3, 2, "Ramallah" },
                    { 4, 3, "Amman" },
                    { 5, 4, "Beirut" }
                });

            migrationBuilder.InsertData(
                table: "SubGroups",
                columns: new[] { "Id", "MainGroupId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Mobile Phones" },
                    { 2, 1, "Laptops" },
                    { 3, 2, "Men's Wear" },
                    { 4, 2, "Women's Wear" },
                    { 5, 3, "Kitchen Appliances" }
                });

            migrationBuilder.InsertData(
                table: "SubGroup2s",
                columns: new[] { "Id", "MainGroupId", "Name", "SubGroupId" },
                values: new object[,]
                {
                    { 1, 1, "Smartphones", 1 },
                    { 2, 2, "Gaming Laptops", 2 },
                    { 3, 3, "Shirts", 3 },
                    { 4, 3, "Dresses", 4 },
                    { 5, 1, "Blenders", 5 }
                });

            migrationBuilder.InsertData(
                table: "Zone",
                columns: new[] { "Id", "CityId", "GovernmentId", "Name" },
                values: new object[,]
                {
                    { 1, 1, 1, "Cairo Zone" },
                    { 2, 2, 1, "Alex Zone" },
                    { 3, 3, 2, "Ramallah Zone" },
                    { 4, 4, 3, "Amman Zone" },
                    { 5, 5, 4, "Beirut Zone" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "CityId", "ClassificationId", "ConcurrencyStamp", "Email", "EmailConfirmed", "GovernmentId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "ZoneId" },
                values: new object[,]
                {
                    { 1, 0, 1, 1, "9f35d73c-d3bf-4af2-857f-b411d8b4d156", "userone@example.com", true, 1, false, null, "USERONE@EXAMPLE.COM", "USERONE", "AQAAAAIAAYagAAAAEA3k1YgV+0bmv3lrxpL7SYo9zMwKaJBK9pwRFZeDzpaTzSUdpKXaHfrO/ypNU5NHZQ==", null, false, "f204314d-25a4-454d-a941-7355ccbd5591", false, "userone", 1 },
                    { 2, 0, 2, 1, "6a2a41d3-8169-4d0c-bc35-61180e02e206", "usertwo@example.com", true, 1, false, null, "USERTWO@EXAMPLE.COM", "USERTWO", "AQAAAAIAAYagAAAAEPRHV6QgXffVubeJ1CNbLXgSg+UtXaQ8a4meLgdBUtS/8ovxnKfMzUa6asI1NtW+fA==", null, false, "8b0d3e2f-122e-4436-aaf9-8d9e17568212", false, "usertwo", 2 },
                    { 3, 0, 3, 2, "269b0d2b-7463-4eeb-9698-93fc8f12fb39", "userthree@example.com", true, 2, false, null, "USERTHREE@EXAMPLE.COM", "USERTHREE", "AQAAAAIAAYagAAAAECPNZxv9FEmNezmOxQIRGOqUNmgy1TzE/8x+NcF8YUZHZ/j6d6tOqHUxNoX+0lKNDw==", null, false, "11b92e1d-4700-4e4a-9966-683532c9fb2f", false, "userthree", 3 },
                    { 4, 0, 4, 2, "0fc6f670-b130-40d6-9280-e6033fda8c06", "userfour@example.com", true, 2, false, null, "USERFOUR@EXAMPLE.COM", "USERFOUR", "AQAAAAIAAYagAAAAEKWUXx+8FIFZ/B9B8dU+QJ01ArySuBwxi0kuhEQZxFf6qKeR8IIPBGJrG4pHNz8N4g==", null, false, "e1316c07-9211-4963-90fe-eae53c8cd88b", false, "userfour", 4 },
                    { 5, 0, 5, 3, "a2a3cfde-601d-4b8f-b929-c7f082b4e6b6", "userfive@example.com", true, 3, false, null, "USERFIVE@EXAMPLE.COM", "USERFIVE", "AQAAAAIAAYagAAAAEHATr+uiBct4kSuCII3v6m83wi+ufV/LR3fJ/EkSBVuE7DNjK9x1zXq3rOOtE3I79g==", null, false, "01f2bfda-e57a-4444-9d40-70ef255a0923", false, "userfive", 5 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "MainGroupId", "Name", "Price", "SubGroup2Id", "SubGroupId" },
                values: new object[,]
                {
                    { 1, "Latest Apple smartphone", 1, "iPhone 14", 999.99000000000001, 1, 1 },
                    { 2, "High performance laptop", 1, "Dell XPS 15", 1500.0, 2, 2 },
                    { 3, "Comfortable cotton shirt", 2, "Men's Casual Shirt", 35.5, 3, 3 },
                    { 4, "Light and breezy", 2, "Women's Summer Dress", 45.990000000000002, 4, 4 },
                    { 5, "Flagship Samsung phone", 1, "Samsung Galaxy S22", 850.0, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "Id", "CityId", "GovernmentId", "Name", "ZoneId" },
                values: new object[,]
                {
                    { 1, 1, 1, "Downtown Electronics", 1 },
                    { 2, 2, 1, "City Fashion Outlet", 2 },
                    { 3, 3, 2, "Home Goods Central", 3 },
                    { 4, 4, 2, "Sports Hub", 4 },
                    { 5, 5, 3, "Beauty Essentials", 5 }
                });

            migrationBuilder.InsertData(
                table: "CustomerStores",
                columns: new[] { "CustomerId", "StoreId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "InventoryItems",
                columns: new[] { "ItemId", "StoreId", "Balance", "Factor", "LastUpdated", "ReservedQuantity", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 100.0, 1, new DateTime(2025, 7, 11, 12, 56, 56, 361, DateTimeKind.Utc).AddTicks(6446), 10.0, 1 },
                    { 2, 1, 50.0, 2, new DateTime(2025, 7, 11, 12, 56, 56, 361, DateTimeKind.Utc).AddTicks(6449), 5.0, 2 },
                    { 3, 2, 75.0, 1, new DateTime(2025, 7, 11, 12, 56, 56, 361, DateTimeKind.Utc).AddTicks(6450), 0.0, 3 },
                    { 4, 3, 120.0, 3, new DateTime(2025, 7, 11, 12, 56, 56, 361, DateTimeKind.Utc).AddTicks(6452), 15.0, 4 },
                    { 5, 3, 200.0, 1, new DateTime(2025, 7, 11, 12, 56, 56, 361, DateTimeKind.Utc).AddTicks(6453), 20.0, 5 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "CreatedAt", "CustomerId", "IsClosed", "IsPosted", "IsReviewed", "NetPrice", "PaymentType", "TransactionType", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 1, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1443), 1, false, true, true, 150.75, 1, 1, new DateTime(2025, 7, 6, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1451) },
                    { 2, new DateTime(2025, 7, 3, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1454), 2, false, false, false, 299.99000000000001, 2, 2, new DateTime(2025, 7, 7, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1454) },
                    { 3, new DateTime(2025, 7, 4, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1457), 3, false, true, false, 75.5, 1, 1, new DateTime(2025, 7, 8, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1458) },
                    { 4, new DateTime(2025, 7, 5, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1460), 4, true, true, true, 450.0, 3, 2, new DateTime(2025, 7, 9, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1460) },
                    { 5, new DateTime(2025, 7, 6, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1462), 5, false, true, true, 1200.0, 1, 1, new DateTime(2025, 7, 10, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(1463) }
                });

            migrationBuilder.InsertData(
                table: "ItemUnits",
                columns: new[] { "ItemId", "UnitId", "Factor" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 1 },
                    { 3, 1, 1 },
                    { 4, 1, 1 },
                    { 5, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCartItems",
                columns: new[] { "CustomerId", "StoreId", "CreatedAt", "ItemId", "Quantity", "UnitId", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 7, 11, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 2.0, 1, null },
                    { 1, 2, new DateTime(2025, 7, 10, 9, 30, 0, 0, DateTimeKind.Unspecified), 2, 5.0, 1, new DateTime(2025, 7, 10, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2025, 7, 9, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 1.5, 2, null },
                    { 3, 3, new DateTime(2025, 7, 8, 16, 30, 0, 0, DateTimeKind.Unspecified), 4, 10.0, 3, new DateTime(2025, 7, 9, 8, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2025, 7, 7, 11, 15, 0, 0, DateTimeKind.Unspecified), 5, 3.0, 4, null }
                });

            migrationBuilder.InsertData(
                table: "InvoicesDetails",
                columns: new[] { "InvoiceId", "ItemId", "CreatedAt", "Factor", "Price", "Quantity", "UnitId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 7, 1, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(7740), 1.0, 30, 2, 1 },
                    { 1, 2, new DateTime(2025, 7, 1, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(7746), 1.0, 20, 1, 2 },
                    { 2, 3, new DateTime(2025, 7, 3, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(7749), 1.0, 15, 3, 1 },
                    { 3, 4, new DateTime(2025, 7, 4, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(7752), 1.0, 50, 1, 3 },
                    { 5, 5, new DateTime(2025, 7, 6, 12, 56, 56, 362, DateTimeKind.Utc).AddTicks(7762), 1.0, 100, 5, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "CustomerStores",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerStores",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "CustomerStores",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CustomerStores",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "CustomerStores",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumns: new[] { "ItemId", "UnitId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumns: new[] { "ItemId", "UnitId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumns: new[] { "ItemId", "UnitId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumns: new[] { "ItemId", "UnitId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ItemUnits",
                keyColumns: new[] { "ItemId", "UnitId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "MainGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MainGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ShoppingCartItems",
                keyColumns: new[] { "CustomerId", "StoreId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubGroup2s",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubGroups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SubGroup2s",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubGroup2s",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubGroup2s",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubGroup2s",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Classifications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MainGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SubGroups",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SubGroups",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Zone",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MainGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MainGroups",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Governments",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
