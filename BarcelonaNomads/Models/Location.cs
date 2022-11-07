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
        public string Address { get; set; }
        public LocationType LocationType { get; set; }

        // Relationships
        public List<Review> Reviews { get; set; }

        public Location()
        { 

        }
    }
}