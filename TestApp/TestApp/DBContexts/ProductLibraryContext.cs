using TestApp.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace TestApp.DbContexts
{
    public class ProductLibraryContext : DbContext
    {
        public ProductLibraryContext(DbContextOptions<ProductLibraryContext> options)
           : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // seed the database with dummy data
            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = Guid.Parse("d29888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Food",

                },
                new Category()
                {
                    Id = Guid.Parse("da2fd509-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Toys",

                },
                new Category()
                {
                    Id = Guid.Parse("2902b664-1190-4c70-9915-b9c2d7680450"),
                    Name = "Electronics",

                },
                new Category()
                {
                    Id = Guid.Parse("112b566b-ba1f-404c-b2df-e2cde39ade09"),
                    Name = "Animals",

                },
                new Category()
                {
                    Id = Guid.Parse("5b3632c0-7b12-4e80-9c8b-3398cba7ee05"),
                    Name = "Furniture",

                },
                new Category()
                {
                    Id = Guid.Parse("2aadd2df-7caf-45ab-9355-7f6732985a87"),
                    Name = "Drinks",

                }
                );

            modelBuilder.Entity<Product>().HasData(
               new Product
               {
                   Id = Guid.Parse("340c2c6b-0d1c-4b82-9d83-3cf635a3e62b"),
                   CategoryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                   Name = "Chocolate",
                   Quantity = "1",
                   Price = "20",
                   ImgURL = "www.google.com"

               },
               new Product
               {
                   Id = Guid.Parse("d94a64c2-2e8f-4162-9976-0ffe02d30767"),
                   CategoryId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                   Name = "Doll",
                   Quantity = "3",
                   Price = "10",
                   ImgURL = "www.google.com"
               },
               new Product
               {
                   Id = Guid.Parse("5b1c2b4d-45c7-402a-80c3-cc796ad49c6b"),
                   CategoryId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                   Name = "Laptop",
                   Quantity = "10",
                   Price = "100000",
                   ImgURL = "www.google.com"
               },
               new Product
               {
                   Id = Guid.Parse("129f9ccb-149d-4d3c-ad4f-40100f38e918"),
                   CategoryId = Guid.Parse("112b566b-ba1f-404c-b2df-e2cde39ade09"),
                   Name = "Cat",
                   Quantity = "2",
                   Price = "100",
                   ImgURL = "www.google.com"
               }
               );

            base.OnModelCreating(modelBuilder);
        }
    }
}