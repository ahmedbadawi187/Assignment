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
    public class SupplierSevices : ISupplierSevices
    {
        public readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public SupplierSevices(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        public async Task<SupplierModel> GetById(int id)
        {
            var obj = new Supplier();
            if (id > 0)
                obj = await _supplierRepository.GetById(id);

            var model = _mapper.Map<SupplierModel>(obj);

            return model;
        }
        public async Task Save(SupplierModel model)
        {
            var obj = new Supplier();
            if (model.Id > 0)
                obj = await _supplierRepository.GetById(model.Id);

            _mapper.Map(model, obj);

            await _supplierRepository.Update(obj);

        }
        public async Task<bool> ChangeStatus(int id, bool status)
        {
            var obj = await _supplierRepository.GetById(id);
            if (obj == null)
                return false;

            obj.IsPublish = status;

             await _supplierRepository.Update(obj);

            return true;
        }
        public async Task<bool> Delete(int id)
        {
            var obj = await _supplierRepository.GetById(id);
            if (obj == null)
                return false;

            obj.IsDeleted = true;

            await _supplierRepository.Update(obj);

            return true;
        }
        public async Task<ResponseListModel<SupplierViewModel>> LoadData( string search = null, int statusId = 0,int pageIndex = 0, int pageSize = 10)
        {
            var data = await _supplierRepository.LoadItemsData(search, statusId, pageIndex, pageSize);

            var list = data.Item1.Select(obj =>
            {
                var model = _mapper.Map<SupplierViewModel>(obj);

                return model;
            });

            return new ResponseListModel<SupplierViewModel>()
            {
                Data = list,
                TotalRecords = data.Item2,
            };
        }
        public async Task<SupplierViewModel> GetLargestSupplierInSore()
        {
            var obj = await _supplierRepository.GetLargestSupplierInSore();

            var model = _mapper.Map<SupplierViewModel>(obj.Item1);
            model.TotalProducts = obj.Item2;

            return model;
        }
    }
}
