using Assignment.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Interfaces
{
    public interface ISupplierRepository
    {
        Task<Supplier> GetById(int id);
        Task Update(Supplier obj);
        Task<Tuple<IEnumerable<Supplier>, int>> LoadItemsData(string search, int statusId, int pageIndex = 0,
                     int pageSize = 10);
        Task<Tuple<Supplier,int>> GetLargestSupplierInSore();
    }
}
