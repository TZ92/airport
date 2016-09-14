using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;

namespace Web.Models
{
    public class CreateFlightViewModel
    {
        public String Number { get; set; }

        public int DepartLocationId { get; set; }
        public int ArrivalLocationId { get; set; }
        public int PlaneId { get; set; }
        public int AirlinecompanyId { get; set; }

        public int price { get; set; }
        public DateTime ArrivalDate { get; set; }
        public DateTime DepartDate { get; set; }

        public int NumberStops { get; set; }
        public int FlightDuration { get; set; }
        public int FlightMiles { get; set; }

    }

}