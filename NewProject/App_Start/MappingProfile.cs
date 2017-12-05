using AutoMapper;
using NewProject.Dto;
using NewProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewProject.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Products, ProductsDto>();
            Mapper.CreateMap<Categories, CategoriesDto>();
            Mapper.CreateMap<Suppliers, SuppliersDto>();

            Mapper.CreateMap<ProductsDto, Products>()
            .ForMember(m => m.ProductID, opt => opt.Ignore());
        }
    }
}