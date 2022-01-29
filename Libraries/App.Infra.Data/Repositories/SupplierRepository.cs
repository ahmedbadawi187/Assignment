
using Microsoft.EntityFrameworkCore;
using Assignment.Domain.Interfaces;
using Assignment.Domain.Model;
using Assignment.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Infra.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        public AppDbContext _context;
        public SupplierRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Supplier> GetById(int Id)
        {
            return await _context.Suppliers
                .Where(x => x.Id == Id && !x.IsDeleted)
                .FirstOrDefaultAsync();
        }
     
        public async Task Update(Supplier obj)
        {
            if (obj.Id == 0)
            {
                await _context.Suppliers.AddAsync(obj);
            }
            else
            {
                _context.Entry(obj).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
        public async Task<Tuple<IEnumerable<Supplier>, int>> LoadItemsData(string search, int statusId, int pageIndex = 0,
                int pageSize = 10)
        {
            var AllListCount = 0;
            var dataQuery = _context.Suppliers
                .Where(x =>
                (statusId == 0 || (statusId == 1 && x.IsPublish == true)
                || (statusId == 2 && x.IsPublish == false)) && !x.IsDeleted);

            if (!string.IsNullOrEmpty(search))
            {
                dataQuery = dataQuery.Where(x => x.Name.Contains(search));
            }

            var result = dataQuery.AsQueryable();

            result = result.OrderByDescending(x => x.Id);

            AllListCount = await dataQuery.CountAsync();

            return new Tuple<IEnumerable<Supplier>, int>(await result.Skip(pageIndex).Take(pageSize).ToListAsync(), AllListCount);
        }
        public async Task<Tuple<Supplier,int>> GetLargestSupplierInSore()
        {
            var dataQuery = _context.Products
                .Where(x => x.IsPublish && !x.IsDeleted && x.Supplier.IsPublish 
                            && !x.Supplier.IsDeleted);

            var result = await dataQuery.GroupBy(s=> s.SupplierId).Select(g=> new
            {
                supplierId = g.Key,
                totalProduct = g.Count(),
            }).OrderByDescending(g=> g.totalProduct).FirstOrDefaultAsync();

            var supplier = await _context.Suppliers.Where(g=> g.Id == result.supplierId).FirstOrDefaultAsync();

            return new Tuple<Supplier, int>(supplier, result.totalProduct);
        }
    }
}
