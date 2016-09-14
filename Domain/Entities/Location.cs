using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Location
    {
        public Location()
        {
            //            this.t_flight = new List<t_flight>();
            //            this.t_flight1 = new List<t_flight>();
            this.FlightDepart = new List<Flight>();
            this.FlightArrival = new List<Flight>();
        }

        public int LocationId { get; set; }
        public string AirportCode { get; set; }
        public string AirportName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Nullable<int> TimeZone { get; set; }
        public Nullable<int> ZipCode { get; set; }
        public virtual ICollection<Flight> FlightDepart { get; set; }
        public virtual ICollection<Flight> FlightArrival { get; set; }
    }
}
