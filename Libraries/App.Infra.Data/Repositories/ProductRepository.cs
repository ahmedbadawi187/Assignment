
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
    public class ProductRepository : IProductRepository
    {
        public AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product> GetById(int Id)
        {
            return await _context.Products
                .Where(x => x.Id == Id && !x.IsDeleted)
                .FirstOrDefaultAsync();
        }
        public async Task Update(Product obj)
        {
            if (obj.Id == 0)
            {
                await _context.Products.AddAsync(obj);
            }
            else
            {
                _context.Entry(obj).State = EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
        public async Task<Tuple<IEnumerable<Product>, int>> LoadProductsList(string Search, int StatusId, int supplierId, int pageIndex = 0,
            int pageSize = 10)
        {
            var AllListCount = 0;
            var dataQuery = _context.Products
                .Where(x =>
                (StatusId == 0 || (StatusId == 1 && x.IsPublish == true)
                || (StatusId == 2 && x.IsPublish == false)) && !x.IsDeleted);

            if (!string.IsNullOrEmpty(Search))
            {
                dataQuery = dataQuery.Where(x => x.Name.Contains(Search));
            }
            if (supplierId > 0)
            {
                dataQuery = dataQuery.Where(x => x.SupplierId == supplierId);
            }
            var result = dataQuery.Include(s=> s.Supplier).AsQueryable();

            result = result.OrderByDescending(x => x.Id);

            AllListCount = await dataQuery.CountAsync();

            return new Tuple<IEnumerable<Product>, int>(await result.Skip(pageIndex).Take(pageSize).ToListAsync(), AllListCount);
        }
        public async Task<Tuple<IEnumerable<Product>, int>> LoadProductsReOrder(int pageIndex = 0,int pageSize = 10)
        {
            var AllListCount = 0;
            var dataQuery = _context.Products
                .Where(x => x.IsPublish && !x.IsDeleted && x.UnitsInStock <= x.ReorderLevel);

            var result = dataQuery.Include(s => s.Supplier).AsQueryable();

            result = result.OrderBy(x => x.ReorderLevel);

            AllListCount = await dataQuery.CountAsync();

            return new Tuple<IEnumerable<Product>, int>(await result.Skip(pageIndex).Take(pageSize).ToListAsync(), AllListCount);
        }
        public async Task<Tuple<IEnumerable<Product>, int>> LoadProductsMinimumOrders(int pageIndex = 0, int pageSize = 10)
        {
            var AllListCount = 0;
            var dataQuery = _context.Products
                .Where(x => x.IsPublish && !x.IsDeleted);

            var result = dataQuery.Include(s => s.Supplier).AsQueryable();

            result = result.OrderBy(x => x.UnitsOnOrder);

            AllListCount = await dataQuery.CountAsync();

            return new Tuple<IEnumerable<Product>, int>(await result.Skip(pageIndex).Take(pageSize).ToListAsync(), AllListCount);
        }
    }
}
