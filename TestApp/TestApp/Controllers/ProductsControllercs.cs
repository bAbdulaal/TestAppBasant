using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TestApp.Services;
using TestApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPITask.Controllers
{
    [ApiController]
    [Route("products")]

    public class ProductsController : ControllerBase
    {

        private readonly IProductLibraryRepository _productLibraryRepository;
        private readonly IMapper _mapper;
        public ProductsController(IProductLibraryRepository productLibraryRepository, IMapper mapper)
        {
            _productLibraryRepository = productLibraryRepository ??
                throw new ArgumentNullException(nameof(productLibraryRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<ProductsDto>> GetAllProducts()
        //{
        //    var productsrepo = _productLibraryRepository.GetProducts();

        //    return Ok(_mapper.Map<IEnumerable<ProductsDto>>(productsrepo));
        //}

        [HttpGet("{productId}", Name = "GetProduct")]
        public ActionResult<IEnumerable<ProductsDto>> GetProduct(Guid productId, [FromQuery] ProductsParameters productarameter)
        {
            var productsrepo = _productLibraryRepository.GetProduct(productId, productarameter);

            if (productsrepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ProductsDto>>(productsrepo));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductsDto>> GetProductCategory(Guid CategoryId, [FromQuery] ProductsParameters productarameter)
        {
            var productsrepo = _productLibraryRepository.GetProductsCategory(CategoryId, productarameter);

            if (productsrepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<ProductsDto>>(productsrepo));
        }

        [HttpPost]
        public ActionResult<ProductsDto> PostProduct(ProductsCreateDto productsCreateDto)
        {

            var product = _mapper.Map<TestApp.Entities.Product>(productsCreateDto);
            _productLibraryRepository.AddProduct(product);
            _productLibraryRepository.Save();

            var ProductToReturn = _mapper.Map<ProductsDto>(product);
            return CreatedAtRoute("GetProduct",
               new { productId = ProductToReturn.Id },
               ProductToReturn);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(Guid productId, ProductUpdateDto productUpdateDto)
        {
            //if (!_productLibraryRepository.ProductExists(productId))
            //{
            //    return NotFound();
            //}

            var ProductRepo = _productLibraryRepository.FetchProduct(productId);

            if (ProductRepo == null)
            {
                var productAdd = _mapper.Map<TestApp.Entities.Product>(productUpdateDto);
                productAdd.Id = productId;

                _productLibraryRepository.AddProduct(productAdd);

                _productLibraryRepository.Save();

                var productToReturn = _mapper.Map<ProductsDto>(productAdd);

                return CreatedAtRoute("GetProduct",
              new { productId = productToReturn.Id },
              productToReturn);
            }
            _mapper.Map(productUpdateDto, ProductRepo);
            _productLibraryRepository.UpdateProduct(ProductRepo);
            _productLibraryRepository.Save();
            return NoContent();
        }

        [HttpPatch("{productId}")]
        public ActionResult PatchProduct(Guid productId, JsonPatchDocument<ProductUpdateDto> patchDocument)
        {
            var ProductRepo = _productLibraryRepository.FetchProduct(productId);


            var productToPatch = _mapper.Map<ProductUpdateDto>(ProductRepo);
            patchDocument.ApplyTo(productToPatch);

            _mapper.Map(productToPatch, ProductRepo);

            _productLibraryRepository.UpdateProduct(ProductRepo);

            _productLibraryRepository.Save();

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public ActionResult DeleteCourseForAuthor(Guid productId)
        {


            var ProductRepo = _productLibraryRepository.FetchProduct(productId);

            if (ProductRepo == null)
            {
                return NotFound();
            }

            _productLibraryRepository.DeleteProduct(ProductRepo);
            _productLibraryRepository.Save();
            return NoContent();
        }
    }
}