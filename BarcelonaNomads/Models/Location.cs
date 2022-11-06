using System;
using System.ComponentModel.DataAnnotations;
using BarcelonaNomads.Data;

namespace BarcelonaNomads.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public LocationType LocationType { get; set; }

        // Relationships
        public List<Review> Review { get; set; }

        public Location()
        { 

        }
    }
}