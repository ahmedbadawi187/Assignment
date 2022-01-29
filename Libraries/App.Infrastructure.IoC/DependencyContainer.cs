using Assignment.Application.Profiles;
using Assignment.Application.Interfaces;
using Assignment.Application.Services;
using Assignment.Domain.Interfaces;
using Assignment.Infra.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using AutoMapper;

namespace Assignment.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Repository
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();

            //Sevices
            services.AddScoped<ISupplierSevices, SupplierSevices>();
            services.AddScoped<IProductSevices, ProductSevices>();
            services.AddScoped<ILookupSevices, LookupSevices>();

            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}