using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarcelonaNomads.Models;

namespace BarcelonaNomad.Data.Services
{
    public interface ILocationsService
    {
        Task<IEnumerable<Location>> GetAll();
        Task<Location> Get(int id);
        void Add(Location location);
        Location Update(int id, Location location);
        void Delete(int id);
    }
}
