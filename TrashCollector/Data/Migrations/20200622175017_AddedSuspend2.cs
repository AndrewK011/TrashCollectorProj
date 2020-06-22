using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedSuspend2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69b411b8-5e5b-4b00-8387-112176ff89b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "779f7bcf-532d-4596-becc-b67674852ab4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a75e850b-c13b-49ed-aeea-9706c2faf1f9", "c72c82b8-f691-48a4-b4a0-de9e6a3941eb", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5defcf17-e2fc-4cfc-b09f-82511e0e4d7e", "fe95caa7-3d55-40f2-a40e-f248cce81602", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5defcf17-e2fc-4cfc-b09f-82511e0e4d7e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a75e850b-c13b-49ed-aeea-9706c2faf1f9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69b411b8-5e5b-4b00-8387-112176ff89b2", "1fa6d6ea-4d14-41b5-bd53-a248b9ed3ea2", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "779f7bcf-532d-4596-becc-b67674852ab4", "92d91217-b32b-402d-8d18-5493206a2e43", "Customer", "CUSTOMER" });
        }
    }
}
