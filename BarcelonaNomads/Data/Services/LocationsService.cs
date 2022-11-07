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

        public async Task AddAsync(Location location)
        {
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Location> GetAsync(int id)
        {
            var location = await _context.Locations
                .Include(l => l.Reviews)
                .FirstOrDefaultAsync(l => l.Id == id);

            return location;
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            var locations = await _context.Locations.Include(l => l.Reviews).ToListAsync();
            return locations;
        }

        public async Task<Location> UpdateAsync(int id, Location location)
        {
            _context.Update(location);
            await _context.SaveChangesAsync();
            return location;
        }
    }
}
