using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPITask.Profiles
{
    public class CategoriesProfile : Profile
    {
        public CategoriesProfile()
        {
            CreateMap<TestApp.Entities.Category, TestApp.Models.CategoriesDto>();
        }
    }
}