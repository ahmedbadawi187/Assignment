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
    public class LookupSevices : ILookupSevices
    {
        public readonly ILookupRepository _lookupRepository;
        private readonly IMapper _mapper;
        public LookupSevices(ILookupRepository lookupRepository, IMapper mapper)
        {
            _lookupRepository = lookupRepository;
            _mapper = mapper;
        }
        public async Task<ResponseListModel<BaseViewModel>> GetAllUnits()
        {
            var data = await _lookupRepository.GetAllUnits();

            var list = data.Select(obj =>
            {
                var model = _mapper.Map<BaseViewModel>(obj);

                return model;
            });

            return new ResponseListModel<BaseViewModel>()
            {
                Data = list,
                TotalRecords = list.Count(),
            };
        }
    }
}
