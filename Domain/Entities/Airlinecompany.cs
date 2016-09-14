using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Airlinecompany
    {
        public Airlinecompany()
        {
            this.Flights = new List<Flight>();
            this.EmpAirlines = new List<EmpAirline>();
        }

        public int AirlinecompanyId { get; set; }
        public string Address { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }
        public string Continent { get; set; }
        public string Contry { get; set; }
        public string Logo { get; set; }
        [Required(ErrorMessage = "you must give a name")]
        public string Name { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        public Nullable<int> Rate { get; set; }
        [Required(ErrorMessage = "please enter the URL site web")]
        [Display(Name = "Site Web")]
        [DataType(DataType.Url)]
        public string SiteWeb { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
        public virtual ICollection<EmpAirline> EmpAirlines { get; set; }
    }
}
