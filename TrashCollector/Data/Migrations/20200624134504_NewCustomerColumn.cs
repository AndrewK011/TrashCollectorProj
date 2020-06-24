using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class NewCustomerColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d086b497-5689-4093-8894-98a721a79411");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f98d249e-6725-4432-9804-893cc89cf94e");

            migrationBuilder.AddColumn<bool>(
                name: "WeeklyPickupConfirmed",
                table: "Customers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cccbeb99-2ef7-4528-9a36-7e020bddc54e", "4388c669-70ad-4b9d-996e-7a01527ddac7", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "68c8d043-c6ff-4187-b347-d99e7f45f910", "b89faee6-eefa-49af-95b1-eebe009097f4", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "68c8d043-c6ff-4187-b347-d99e7f45f910");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cccbeb99-2ef7-4528-9a36-7e020bddc54e");

            migrationBuilder.DropColumn(
                name: "WeeklyPickupConfirmed",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f98d249e-6725-4432-9804-893cc89cf94e", "1502fe17-3029-4b5d-8bf3-7fed2c4c91a3", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d086b497-5689-4093-8894-98a721a79411", "d08e72ab-38ff-4d03-b4c9-ade32c846d1b", "Customer", "CUSTOMER" });
        }
    }
}
