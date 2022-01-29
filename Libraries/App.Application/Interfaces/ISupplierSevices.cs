using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment.Application.ViewModels;
using Assignment.Application.Model;
using System.Threading.Tasks;
using System;
using Assignment.Domain.Model;

namespace Assignment.Application.Interfaces
{
    public interface ISupplierSevices
    {
        Task<SupplierModel> GetById(int id);
        Task Save(SupplierModel model);
        Task<bool> ChangeStatus(int id, bool status);
        Task<bool> Delete(int id);
        Task<ResponseListModel<SupplierViewModel>> LoadData(string search = null, int statusId = 0,int pageIndex = 0, int pageSize = 10);
        Task<SupplierViewModel> GetLargestSupplierInSore();
    }
}