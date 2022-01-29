using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Assignment.Application.ViewModels;
using Assignment.Application.Model;
using System.Threading.Tasks;
using System;
using Assignment.Domain.Model;

namespace Assignment.Application.Interfaces
{
    public interface ILookupSevices
    {
        Task<ResponseListModel<BaseViewModel>> GetAllUnits();
    }
}