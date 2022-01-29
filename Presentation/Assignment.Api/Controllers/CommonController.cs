using Assignment.Application.Interfaces;
using Assignment.Domain.Model;
using Assignment.Application.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommonController : ControllerBase
    {
        private readonly ILookupSevices _lookupSevices;
        public CommonController(ILookupSevices lookupSevices)
        {
            _lookupSevices = lookupSevices;
        }
       
        [HttpGet]
        [Route("GetAllUnits")]
        public async Task<IActionResult> GetAllUnits()
        {
            var data = await _lookupSevices.GetAllUnits();

            return Ok(data);
        }
    }
}
