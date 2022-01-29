using Assignment.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetById(int id);
        Task Update(Product obj);
        Task<Tuple<IEnumerable<Product>, int>> LoadProductsList(string search, int statusId, int supplierId, int pageIndex = 0,
       int pageSize = 10);
        Task<Tuple<IEnumerable<Product>, int>> LoadProductsReOrder(int pageIndex = 0, int pageSize = 10);
        Task<Tuple<IEnumerable<Product>, int>> LoadProductsMinimumOrders(int pageIndex = 0, int pageSize = 10);
    }
}
