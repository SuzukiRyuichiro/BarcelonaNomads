using System;
using BarcelonaNomads.Models;
using Microsoft.EntityFrameworkCore;

namespace BarcelonaNomads.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (
                var context = new ApplicationDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()
                )
            )
            {
                if (!context.Locations.Any())
                {
                    context.Locations.AddRange(
                        entities: new List<Location>()
                        {
                            new Location
                            {
                                Name = "Santander Work Cafe",
                                Address = "Passeig de Gràcia, 54, 08007 Barcelona, Spain",
                                LocationType = LocationType.Cafe
                            },
                            new Location
                            {
                                Name = "Imagin Cafe",
                                Address = "C. de Pelai, 11, 08008 Barcelona, Spain",
                                LocationType = LocationType.Cafe
                            },
                            new Location
                            {
                                Name = "Monday Barceloneta",
                                Address = "Pg. de Joan de Borbó, 99, 08039 Barcelona, Spain",
                                LocationType = LocationType.CoworkingSpace
                            },
                            new Location
                            {
                                Name = "Muss & Coco",
                                Address = "C. de les Santjoanistes, 24, 08006 Barcelona, Spain",
                                LocationType = LocationType.Cafe
                            }
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
