using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarcelonaNomads.Models;

namespace BarcelonaNomad.Data.Services
{
    public interface ILocationsService
    {
        Task<IEnumerable<Location>> GetAllAsync();
        Task<Location> GetAsync(int id);
        Task AddAsync(Location location);
        Task<Location> UpdateAsync(int id, Location location);
        void Delete(int id);
    }
}
