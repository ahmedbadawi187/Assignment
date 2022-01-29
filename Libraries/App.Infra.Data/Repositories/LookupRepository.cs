
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
    public class LookupRepository : ILookupRepository
    {
        public AppDbContext _context;
        public LookupRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Unit>> GetAllUnits()
        {
            return await _context.Units.ToListAsync();
        }
    }
}
