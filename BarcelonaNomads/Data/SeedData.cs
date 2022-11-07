using System;
using BarcelonaNomads.Models;
using Microsoft.EntityFrameworkCore;

namespace BarcelonaNomads.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()
            );
            // Locations
            // Delete all Locations in the database

            if (!context.Locations.Any())
            {
                context.Locations.AddRange(
                    entities: new List<Location>()
                    {
                        new Location
                        {
                            Name = "Santander Work Cafe",
                            Address = "Passeig de Gràcia, 54, 08007 Barcelona, Spain",
                            Description =
                                "A coworking space run by Santander. There are plenty of seats available with fast wifi up to 300 Mbps download. All you have to do is to purchase a drink or a snack from the cafe. Each tables comes with a power outlet and a USB port. If you're a Santander customer, you get discounts at the cafe, and you can also use the meeting rooms. Even if you are not a Santander customer, you can still take calls.",
                            ImageURL =
                                "https://res.cloudinary.com/scooter-scooter/image/upload/v1667827412/BarcelonaNomad/santander.jpg",
                            LocationType = LocationType.Cafe
                        },
                        new Location
                        {
                            Name = "Imagin Cafe",
                            Address = "C. de Pelai, 11, 08008 Barcelona, Spain",
                            Description =
                                "A cool atmosphere cafe / coworking space run by Imagin. There are rooms designed for different purposes, yet the WiFi is relatively slow.",
                            ImageURL =
                                "https://res.cloudinary.com/scooter-scooter/image/upload/v1667827412/BarcelonaNomad/imagin.jpg",
                            LocationType = LocationType.Cafe
                        },
                        new Location
                        {
                            Name = "Monday Barceloneta",
                            Address = "Pg. de Joan de Borbó, 99, 08039 Barcelona, Spain",
                            Description =
                                "A coworking space by the beach. It starts from €199 a month, or €29 a day, and you get access to a beautiful space with a view of the beach. The WiFi is fast and reliable.",
                            ImageURL =
                                "https://res.cloudinary.com/scooter-scooter/image/upload/v1667827412/BarcelonaNomad/monday.jpg",
                            LocationType = LocationType.CoworkingSpace
                        },
                        new Location
                        {
                            Name = "IKEA",
                            Address =
                                "Avinguda de la Granvia de l’Hospitalet, 115, 133, 08908 L'Hospitalet de Llobregat, Barcelona, Spain",
                            Description =
                                "Perhaps not intended to used as a work place, but the cafeteria is big and there are a plenty of seats. There is free WiFi that is decently fast. As you may know, food and drinks are cheap, and if you're a IKEA family member, you get free coffee and tea.",
                            ImageURL =
                                "https://res.cloudinary.com/scooter-scooter/image/upload/v1667827412/BarcelonaNomad/ikea.jpg",
                            LocationType = LocationType.Cafe
                        },
                    }
                );
                context.SaveChanges();
            }

            if (!context.Reviews.Any())
            {
                // Reviews
                var ikea = context.Locations.FirstOrDefault(l => l.Name == "IKEA");
                var santander = context.Locations.FirstOrDefault(
                    l => l.Name == "Santander Work Cafe"
                );
                var imagin = context.Locations.FirstOrDefault(l => l.Name == "Imagin Cafe");
                var monday = context.Locations.FirstOrDefault(l => l.Name == "Monday Barceloneta");

                if (ikea == null ^ santander == null ^ imagin == null ^ monday == null)
                {
                    return;
                }

                context.Reviews.AddRange(
                    entities: new List<Review>()
                    {
                        new Review
                        {
                            Location = santander,
                            Content =
                                "Fast wifi and great cappuccino!! You get a discount if you are a Santander customer.",
                        },
                        new Review
                        {
                            Location = imagin,
                            Content = "Wifi here is soooo slow. It's unusable."
                        },
                        new Review
                        {
                            Location = santander,
                            Content =
                                "When I went, it was about to be full. It did become less crowded after 2pm."
                        },
                        new Review
                        {
                            Location = santander,
                            Content =
                                "The staff is very friendly and helpful. Bathrooms are super clean, which is nice."
                        },
                        new Review
                        {
                            Location = santander,
                            Content =
                                "The person next to me was on a call for pretty much entire time I was there. I'm glad that I brought my ANC headphones."
                        },
                        new Review
                        {
                            Location = monday,
                            Content =
                                "My friend who works there invited me once. The place has a lot of natural light and a great atmosphere. I would love to work here."
                        },
                        new Review
                        {
                            Location = ikea,
                            Content =
                                "I went there once to work. I did manage to get concentrated, and it was nice that I could get a coffee for free. I had stuff to buy at IKEA so that was a bonus. There's a big shopping mall next to it as well so if you wanna go shopping but also want to work, it is a neat spot."
                        },
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
