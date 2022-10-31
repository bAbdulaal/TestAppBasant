using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApp.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<string>(maxLength: 10, nullable: true),
                    Quantity = table.Column<string>(maxLength: 10, nullable: true),
                    ImgURL = table.Column<string>(maxLength: 1500, nullable: true),
                    CategoryId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("d29888e9-2ba9-473a-a40f-e38cb54f9b35"), "Food" },
                    { new Guid("da2fd509-d754-4feb-8acd-c4f9ff13ba96"), "Toys" },
                    { new Guid("2902b664-1190-4c70-9915-b9c2d7680450"), "Electronics" },
                    { new Guid("112b566b-ba1f-404c-b2df-e2cde39ade09"), "Animals" },
                    { new Guid("5b3632c0-7b12-4e80-9c8b-3398cba7ee05"), "Furniture" },
                    { new Guid("2aadd2df-7caf-45ab-9355-7f6732985a87"), "Drinks" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "ImgURL", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("340c2c6b-0d1c-4b82-9d83-3cf635a3e62b"), new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "www.google.com", "Chocolate", "20", "1" },
                    { new Guid("d94a64c2-2e8f-4162-9976-0ffe02d30767"), new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "www.google.com", "Doll", "10", "3" },
                    { new Guid("5b1c2b4d-45c7-402a-80c3-cc796ad49c6b"), new Guid("2902b665-1190-4c70-9915-b9c2d7680450"), "www.google.com", "Laptop", "100000", "10" },
                    { new Guid("129f9ccb-149d-4d3c-ad4f-40100f38e918"), new Guid("112b566b-ba1f-404c-b2df-e2cde39ade09"), "www.google.com", "Cat", "100", "2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
