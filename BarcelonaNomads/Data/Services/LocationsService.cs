using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BarcelonaNomads.Data;
using BarcelonaNomads.Models;
using Microsoft.EntityFrameworkCore;

namespace BarcelonaNomad.Data.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly ApplicationDbContext _context;

        public LocationsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Location location)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Location> Get(int id)
        {
            var location = _context.Locations
                ?.Include(l => l.Reviews)
                .FirstOrDefaultAsync(l => l.Id == id);

            return location;
        }

        public async Task<IEnumerable<Location>> GetAll()
        {
            var locations = await _context.Locations.Include(l => l.Reviews).ToListAsync();
            return locations;
        }

        public Location Update(int id, Location location)
        {
            throw new NotImplementedException();
        }
    }
}
