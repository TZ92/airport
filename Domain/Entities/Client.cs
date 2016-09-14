using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Client
    {
        public Client()
        {
            this.Claims = new List<Claim>();
            this.Reservations = new List<Reservation>();
            this.Feedbacks = new List<Feedback>();
            this.Payments = new List<Payment>();
        }

        public int ClientId { get; set; }
        public string CountriesVisited { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> MilesParcoured { get; set; }
        public Nullable<int> NumberTrips { get; set; }
        public string Password { get; set; }
        public Nullable<int> Phone { get; set; }
        public virtual ICollection<Claim> Claims { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
