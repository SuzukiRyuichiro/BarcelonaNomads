using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarcelonaNomads.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        public string content { get; set; }

        // Relationship
        public int LocationId { get; set; }
        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        public Review()
        {
        }
    }
}

