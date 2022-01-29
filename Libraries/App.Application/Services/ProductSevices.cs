using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Localization;
using Assignment.Application.Profiles;
using Assignment.Application.Interfaces;
using Assignment.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment.Domain.Model;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Assignment.Application.ViewModels;
using Assignment.Application.Model;

namespace Assignment.Application.Services
{
    public class ProductSevices : IProductSevices
    {
        public readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductSevices(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductModel> GetById(int id)
        {
            var obj = new Product();
            if (id > 0)
                obj = await _productRepository.GetById(id);

            var model = _mapper.Map<ProductModel>(obj);

            return model;
        }
        public async Task Save(ProductModel model)
        {
            var obj = new Product();
            if (model.Id > 0)
                obj = await _productRepository.GetById(model.Id);

            _mapper.Map(model, obj);

            await _productRepository.Update(obj);

        }
        public async Task<bool> ChangeStatus(int id, bool status)
        {
            var obj = await _productRepository.GetById(id);
            if (obj == null)
                return false;

            obj.IsPublish = status;

            await _productRepository.Update(obj);

            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var obj = await _productRepository.GetById(id);
            if (obj == null)
                return false;

            obj.IsDeleted = true;

            await _productRepository.Update(obj);

            return true;
        }
        public async Task<ResponseListModel<ProductViewModel>> LoadData(string search = null, int statusId = 0, int supplierId = 0 ,
           int pageIndex = 0, int pageSize = 10)
        {
            var data = await _productRepository.LoadProductsList(search, statusId, supplierId, pageIndex, pageSize);

            var list = data.Item1.Select(obj =>
            {
                var model = _mapper.Map<ProductViewModel>(obj);
                model.SupplierName = obj.Supplier != null ? obj.Supplier.Name : null;

                return model;
            });

            return new ResponseListModel<ProductViewModel>()
            {
                Data = list,
                TotalRecords = data.Item2,
            };
        }
        public async Task<ResponseListModel<ProductViewModel>> LoadProductsReOrder(int pageIndex = 0, int pageSize = 10)
        {
            var data = await _productRepository.LoadProductsReOrder(pageIndex, pageSize);

            var list = data.Item1.Select(obj =>
            {
                var model = _mapper.Map<ProductViewModel>(obj);
                model.SupplierName = obj.Supplier != null ? obj.Supplier.Name : null;

                return model;
            });

            return new ResponseListModel<ProductViewModel>()
            {
                Data = list,
                TotalRecords = data.Item2,
            };
        }
        public async Task<ResponseListModel<ProductViewModel>> LoadProductsMinimumOrders(int pageIndex = 0, int pageSize = 10)
        {
            var data = await _productRepository.LoadProductsMinimumOrders(pageIndex, pageSize);

            var list = data.Item1.Select(obj =>
            {
                var model = _mapper.Map<ProductViewModel>(obj);
                model.SupplierName = obj.Supplier != null ? obj.Supplier.Name : null;

                return model;
            });

            return new ResponseListModel<ProductViewModel>()
            {
                Data = list,
                TotalRecords = data.Item2,
            };
        }
    }
}
