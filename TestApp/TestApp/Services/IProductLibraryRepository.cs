using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Entities;
using TestApp.Models;

namespace TestApp.Services
{
    public interface IProductLibraryRepository
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Product> GetProduct(Guid ID, ProductsParameters productarameter);

        public IEnumerable<Product> GetProductsCategory(Guid categoryId, ProductsParameters productarameter);
        void AddProduct(Product product);
        Product FetchProduct(Guid productId);

        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        IEnumerable<Category> GetCategories(CategoriesParameters categoriesParameters);
        public IEnumerable<Category> GetCategory(Guid categoryId, CategoriesParameters categoriesParameters);

        bool ProductExists(Guid productId);
        bool Save();
    }
}
