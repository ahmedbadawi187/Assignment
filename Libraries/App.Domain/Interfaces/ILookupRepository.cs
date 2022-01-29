using Assignment.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Domain.Interfaces
{
    public interface ILookupRepository
    {
        Task<IEnumerable<Unit>> GetAllUnits();
    }
}
