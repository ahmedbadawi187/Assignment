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
    public class ProductController : ControllerBase
    {
        private readonly IProductSevices _productSevices;
        public ProductController(IProductSevices productSevices)
        {
            _productSevices = productSevices;
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var model = await _productSevices.GetById(id);

            return Ok(model);
        }
        [HttpPost]
        [Route("AddEdit")]
        public async Task<IActionResult> AddEdit([FromBody] ProductModel model)
        {
            await _productSevices.Save(model);

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
            await _productSevices.ChangeStatus(model.Id, model.IsPublish);

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
            await _productSevices.Delete(model.Id);

            return Ok(new
            {
                IsSuccess = true,
                Message = "Updated successfully",
            });
        }

        [HttpGet]
        [Route("List")]
        public async Task<IActionResult> List(string search = null, int statusId = 1, int supplierId = 0,
          int pageIndex = 0, int pageSize = 10)
        {
            var data = await _productSevices.LoadData(search, statusId, supplierId, pageIndex, pageSize);

            return Ok(data);
        }

        [HttpGet]
        [Route("LoadProductsReOrder")]
        public async Task<IActionResult> ListProductsReOrder(int pageIndex = 0, int pageSize = 10)
        {
            var data = await _productSevices.LoadProductsReOrder(pageIndex, pageSize);

            return Ok(data);
        }
        [HttpGet]
        [Route("LoadProductsMinimumOrders")]
        public async Task<IActionResult> LoadProductsMinimumOrders(int pageIndex = 0, int pageSize = 10)
        {
            var data = await _productSevices.LoadProductsMinimumOrders(pageIndex, pageSize);

            return Ok(data);
        }
    }
}
