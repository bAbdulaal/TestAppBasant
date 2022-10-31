using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApp.Entities;

namespace RestAPITask.Profiles
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile()
        {
            CreateMap<Product, TestApp.Models.ProductsDto>();
            CreateMap<TestApp.Models.ProductsCreateDto, TestApp.Entities.Product>();
            CreateMap<TestApp.Models.ProductUpdateDto, TestApp.Entities.Product>();
            CreateMap<TestApp.Entities.Product, TestApp.Models.ProductUpdateDto>();
        }
    }
}