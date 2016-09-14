using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Flight
    {
        public Flight()
        {
            //this.Affectations = new List<Affectation>();
            this.Deals = new List<Deal>();
            this.Reservations = new List<Reservation>();
        }

        public int FlightId { get; set; }
        [Display(Name = "Flight Number")]
        [Required]
        [MaxLength(100, ErrorMessage = "Flight Number must be between 3 and 100 characters."), MinLength(3, ErrorMessage = "Flight Number must be between 3 and 100 characters.")]
        public String Number { get; set; }

        public int DepartLocationId { get; set; }
        public int ArrivalLocationId { get; set; }

        public virtual Location DepartLocation { get; set; }
        public virtual Location ArrivalLocation { get; set; }

        [Range(30, 10000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int price { get; set; }

        [Range(typeof(DateTime), "1/12/2015", "3/4/2044",
        ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime ArrivalDate { get; set; }
        [Range(typeof(DateTime), "1/12/2015", "3/4/2044",
       ErrorMessage = "Value for {0} must be between {1} and {2}")]
        public DateTime DepartDate { get; set; }

        public Nullable<System.DateTime> ActualArrival { get; set; }
        public Nullable<System.DateTime> ActualDeparture { get; set; }
        public string FlightStatus { get; set; }

        public Nullable<int> AvailableSeats { get; set; }
        [Range(10, 2000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int FlightDuration { get; set; }
        [Range(10, 50000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int FlightMiles { get; set; }
        public Nullable<int> MilesParcoured { get; set; }
        [Range(0, 10,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int NumberStops { get; set; }






        public int PlaneId { get; set; }
        public virtual Plane Plane { get; set; }

        public int AirlinecompanyId { get; set; }
        public virtual Airlinecompany Airlinecompany { get; set; }


        //public virtual ICollection<Affectation> Affectations { get; set; }
        public virtual ICollection<Deal> Deals { get; set; }
        //public virtual Employee Employee { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }


    }
}
