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
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierSevices _supplierSevices;
        public SupplierController(ISupplierSevices supplierSevices)
        {
            _supplierSevices = supplierSevices;
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _supplierSevices.GetById(id);

            return Ok(model);
        }
        [HttpPost]
        [Route("AddEdit")]
        public async Task<IActionResult> AddEdit([FromBody] SupplierModel model)
        {
            await _supplierSevices.Save(model);

            return Ok(new 
            {
                IsSuccess = true,
                Message = "Updated successfully",
            });
        }
        [HttpPost]
        [Route("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] StatusModel model)
        {
            await _supplierSevices.ChangeStatus(model.Id, model.IsPublish);

            return Ok(new
            {
                IsSuccess = true,
                Message = "Updated successfully",
            });
        }
        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] BaseModel model)
        {
            await _supplierSevices.Delete(model.Id);

            return Ok(new
            {
                IsSuccess = true,
                Message = "Updated successfully",
            });
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(string search = null, int statusId = 1,  int pageIndex = 0, int pageSize = 10)
        {
            var data = await _supplierSevices.LoadData(search, statusId, (pageIndex * pageSize), pageSize);

            return Ok(data);
        }
        [HttpGet]
        [Route("GetLargestSupplierInSore")]
        public async Task<IActionResult> GetLargestSupplierInSore()
        {
            var data = await _supplierSevices.GetLargestSupplierInSore();

            return Ok(data);
        }
    }
}
