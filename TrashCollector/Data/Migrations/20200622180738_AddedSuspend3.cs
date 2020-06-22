using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedSuspend3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "f98d249e-6725-4432-9804-893cc89cf94e", "1502fe17-3029-4b5d-8bf3-7fed2c4c91a3", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d086b497-5689-4093-8894-98a721a79411", "d08e72ab-38ff-4d03-b4c9-ade32c846d1b", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d086b497-5689-4093-8894-98a721a79411");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f98d249e-6725-4432-9804-893cc89cf94e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "a75e850b-c13b-49ed-aeea-9706c2faf1f9", "c72c82b8-f691-48a4-b4a0-de9e6a3941eb", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5defcf17-e2fc-4cfc-b09f-82511e0e4d7e", "fe95caa7-3d55-40f2-a40e-f248cce81602", "Customer", "CUSTOMER" });
        }
    }
}
