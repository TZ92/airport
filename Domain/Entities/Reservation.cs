using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Reservation
    {
        public Reservation()
        {
            this.Passangers = new List<Passanger>();
            this.Payments = new List<Payment>();
        }

        public int ReservationId { get; set; }
        public Nullable<System.DateTime> DateReservation { get; set; }
        public string Status { get; set; }
        public string TravelClass { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> FlightId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Flight Flight { get; set; }
        public virtual ICollection<Passanger> Passangers { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
