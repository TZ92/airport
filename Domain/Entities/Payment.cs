using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public Nullable<int> PaymentAmount { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public string PaymentStatus { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> ReservationId { get; set; }
        public virtual Client Client { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
