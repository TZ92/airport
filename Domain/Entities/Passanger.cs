using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Passanger
    {
        public int PassangerId { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PassportNumber { get; set; }
        public Nullable<int> ReservationId { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
