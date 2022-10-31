using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.DbContexts;
using TestApp.Entities;
using TestApp.Models;

namespace TestApp.Services
{
    public class ProductLibraryRepository : IProductLibraryRepository, IDisposable
    {
        private readonly ProductLibraryContext _context;


        public ProductLibraryRepository(ProductLibraryContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public Product FetchProduct(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _context.Products
              .Where(c => c.Id == productId).FirstOrDefault();
        }



        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.ToList<Product>();
        }

        public IEnumerable<Product> GetProduct(Guid ID, ProductsParameters productarameter)
        {
            if (ID == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ID));
            }

            return _context.Products
                        .Where(c => c.Id == ID)
                        .OrderBy(c => c.Name).ToList().Skip((productarameter.PageNumber - 1) * productarameter.pagesize).Take(productarameter.pagesize);
        }

        public IEnumerable<Product> GetProductsCategory(Guid categoryId, ProductsParameters productarameter)
        {
            if (categoryId == Guid.Empty)
            {
                return _context.Products.ToList<Product>();

            }

            return _context.Products
                        .Where(c => c.CategoryId == categoryId).ToList().Skip((productarameter.PageNumber - 1) * productarameter.pagesize).Take(productarameter.pagesize); ;

        }


        public void UpdateProduct(Product product)
        {
            // no code in this implementation
        }

        public void AddProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }


            _context.Products.Add(product);
        }

        public bool ProductExists(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return _context.Products.Any(a => a.Id == productId);
        }

        public void DeleteProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _context.Products.Remove(product);
        }

        public IEnumerable<Category> GetCategory(Guid categoryId, CategoriesParameters categoriesParameters)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(categoryId));
            }

            return _context.Categories
                       .Where(c => c.Id == categoryId)
                       .ToList().Skip((categoriesParameters.PageNumber - 1) * categoriesParameters.pagesize).Take(categoriesParameters.pagesize);

            //return _context.Categories.FirstOrDefault(a => a.Id == categoryId);
        }

        public IEnumerable<Category> GetCategories(CategoriesParameters categoriesParameters)
        {
            return _context.Categories.ToList<Category>().Skip((categoriesParameters.PageNumber - 1) * categoriesParameters.pagesize).Take(categoriesParameters.pagesize);
        }



        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }
    }
}
