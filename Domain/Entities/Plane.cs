using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public partial class Plane
    {
        public Plane()
        {
            this.Flights = new List<Flight>();
        }

        public int PlaneId { get; set; }

        [Display(Name = "Total number seats")]
        [Range(50, 2000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int TotalSeats { get; set; }

        [Display(Name = "Maximum Speed")]
        [Range(150, 2000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int MaximumSpeed { get; set; }

        [Display(Name = "Plane Name")]
        [Required]
        [MaxLength(100, ErrorMessage = "Plane Name must be between 3 and 100 characters."), MinLength(3, ErrorMessage = "Plane Name must be between 3 and 100 characters.")]
        public string PlaneName { get; set; }

        [Display(Name = "Plug")]
        public Boolean Plug { get; set; }

        [Display(Name = "Wifi")]
        public Boolean Wifi { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
