using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_Backend_Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ResolveNullWarnings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "49fb849e-e5d7-4b31-b25d-4bae05979f97", "AQAAAAIAAYagAAAAEHyxNGznTm0DDVKp9cm30t7cebOMYjGNstWbvKkTkHv/8Z6zLj6PUGr840EMbXBZPw==", "8b1a3b59-3cae-4b60-a6c1-d74cb381681b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "34bfecc4-aa15-4be1-a3a3-f4fcd9b48548", "AQAAAAIAAYagAAAAEGQy4Ii/K8GKUqXpvqw8qyrHqzeEu9FhG2s2DVhiquZ1IJi/J9z1wozgxj/Y8MfABA==", "6fd9ba04-32af-4df7-a017-62c4ac0d1eba" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8d5bd0e8-cb04-45f7-a275-c3f443b06cc3", "AQAAAAIAAYagAAAAEEQ31O37HW8tdZmjkCPzLvWuaPD69LnMN8M9QgS2DM2ESFLHYMCtBIL4mrjJzx4EaQ==", "428050b3-bdd8-4967-9688-299a189fc010" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "625dab48-ac6c-45e8-a39f-227c77f182c4", "AQAAAAIAAYagAAAAEDK2iGvMTPUH1s7M1Ssa7G3rBC5Y2OsVV1upuIAJcrQsiEcuZl1gz9EKqVbxx0etdQ==", "2aca8f30-b306-4cef-8fd0-edecbc5d7fbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e3db2bf6-95f0-4405-b481-c733bbe395e0", "AQAAAAIAAYagAAAAED732xsHC5QwkiBaCsY1Sx8t3TUMywE2ZmXQ/Gr3ydvje60FkSG7wqOys0sGN9H6NQ==", "44578ac7-e362-41f3-becb-db55b92b0341" });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(4451));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(4457));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(4459));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(4460));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(4461));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 2, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9869), new DateTime(2025, 7, 7, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9877) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9880), new DateTime(2025, 7, 8, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9881) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 5, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9883), new DateTime(2025, 7, 9, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9884) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 6, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9886), new DateTime(2025, 7, 10, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9886) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 7, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9890), new DateTime(2025, 7, 11, 17, 0, 55, 939, DateTimeKind.Utc).AddTicks(9891) });

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 17, 0, 55, 940, DateTimeKind.Utc).AddTicks(6633));

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 17, 0, 55, 940, DateTimeKind.Utc).AddTicks(6639));

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 17, 0, 55, 940, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 3, 4 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 0, 55, 940, DateTimeKind.Utc).AddTicks(6645));

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 5, 5 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 17, 0, 55, 940, DateTimeKind.Utc).AddTicks(6658));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14722bb8-2d40-4c0a-b9a6-048ac7a6b7c8", "AQAAAAIAAYagAAAAEA8hqo2ut6NKitFyRlypcN/FJxOh//pZEBNoD2ZdS/FMjD+ZpZ2lQueGTBt9z/rvxQ==", "7160f33a-b887-4ece-9a71-a3a4b9eb8849" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "310281f9-ee75-425a-bc87-e6e79f203210", "AQAAAAIAAYagAAAAEF8OmUhwDeSuXrxKjH8Db58Ma7Px7QVjOwSRXrYfshal0FTwcvL1ie1iNFbYKQDo/w==", "acb85b35-4328-41ab-b6d7-25c0c1e08748" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4a57ac8a-5fef-4e69-8e0d-9b76383fd607", "AQAAAAIAAYagAAAAEGzC6Ztpxpf9Lb0Obdf5uVBeyDg/T9u9LOYoH5MD3OBdDYDJgQOL2U7beFIVuKZgfQ==", "05c8d880-b8d7-4a76-bcbb-d9a2d9d4db5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81bebf6d-349b-4220-ab9f-b53ed01fca63", "AQAAAAIAAYagAAAAEAikNhyLCQmleJq3JmgzHVFGckCAxcikaMyjLt4t1RmFE8Iwyjgt0ITvLD3+lUW7RQ==", "fd4806bf-ebf5-4097-ad5c-e9adfaff81a3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "342e23f2-2d4f-45f6-865c-e27b452757bf", "AQAAAAIAAYagAAAAEPLfyJiYmHmrAosCVFSV+L80dhbltu4cybbZcdBkej0x+Rr3OJRYXlmRPwi/FvRq1g==", "dd3e61d6-64e4-405e-833d-3a7c5cafc225" });

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 1, 1 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 7, 196, DateTimeKind.Utc).AddTicks(5140));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 2, 1 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 7, 196, DateTimeKind.Utc).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 3, 2 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 7, 196, DateTimeKind.Utc).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 4, 3 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 7, 196, DateTimeKind.Utc).AddTicks(5148));

            migrationBuilder.UpdateData(
                table: "InventoryItems",
                keyColumns: new[] { "ItemId", "StoreId" },
                keyValues: new object[] { 5, 3 },
                column: "LastUpdated",
                value: new DateTime(2025, 7, 12, 17, 0, 7, 196, DateTimeKind.Utc).AddTicks(5150));

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 2, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(783), new DateTime(2025, 7, 7, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(795) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 4, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(798), new DateTime(2025, 7, 8, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(799) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 5, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(801), new DateTime(2025, 7, 9, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 6, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(804), new DateTime(2025, 7, 10, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(805) });

            migrationBuilder.UpdateData(
                table: "Invoices",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 7, 7, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(807), new DateTime(2025, 7, 11, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(807) });

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(8285));

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 1, 2 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 2, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(8297));

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 4, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(8300));

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 3, 4 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 5, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(8304));

            migrationBuilder.UpdateData(
                table: "InvoicesDetails",
                keyColumns: new[] { "InvoiceId", "ItemId" },
                keyValues: new object[] { 5, 5 },
                column: "CreatedAt",
                value: new DateTime(2025, 7, 7, 17, 0, 7, 197, DateTimeKind.Utc).AddTicks(8317));
        }
    }
}
