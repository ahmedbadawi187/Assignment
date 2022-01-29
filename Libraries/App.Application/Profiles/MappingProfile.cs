using Assignment.Application.Model;
using Assignment.Application.ViewModels;
using Assignment.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Product
            CreateMap<Product, ProductModel>();

            CreateMap<Product, ProductViewModel>();

            CreateMap<ProductModel, Product>();

            //Supplier
            CreateMap<Supplier, SupplierModel>();

            CreateMap<Supplier, SupplierViewModel>();

            CreateMap<SupplierModel, Supplier>();

            //Supplier
            CreateMap<Unit, BaseViewModel>();
        }
    }
}
