using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrashCollector.Data.Migrations
{
    public partial class AddedSuspend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d481995a-2ee6-4c23-bdc1-0dfd576da555");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9e2f082-9555-45dc-8b5b-87d04f7beb72");

            migrationBuilder.AddColumn<DateTime>(
                name: "SuspendEnd",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "SuspendStart",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "69b411b8-5e5b-4b00-8387-112176ff89b2", "1fa6d6ea-4d14-41b5-bd53-a248b9ed3ea2", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "779f7bcf-532d-4596-becc-b67674852ab4", "92d91217-b32b-402d-8d18-5493206a2e43", "Customer", "CUSTOMER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "69b411b8-5e5b-4b00-8387-112176ff89b2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "779f7bcf-532d-4596-becc-b67674852ab4");

            migrationBuilder.DropColumn(
                name: "SuspendEnd",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SuspendStart",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d9e2f082-9555-45dc-8b5b-87d04f7beb72", "bcdb9222-bb6e-4ae8-b88e-f976ea6859a0", "Employee", "EMPLOYEE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d481995a-2ee6-4c23-bdc1-0dfd576da555", "2afb1e97-216e-4ffe-8b23-8f0c1d62c820", "Customer", "CUSTOMER" });
        }
    }
}
