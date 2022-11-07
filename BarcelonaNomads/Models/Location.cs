using System;
using System.ComponentModel.DataAnnotations;
using BarcelonaNomads.Data;

namespace BarcelonaNomads.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name of the location is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address of the location is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Description of the location is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Image of the location is required.")]
        [Display(Name = "Image URL")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "Type of the location is required.")]
        public LocationType LocationType { get; set; }

        // Relationships
        public List<Review> Reviews { get; set; }

        public Location()
        {
            Reviews = new List<Review>();
        }
    }
}
