using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public string FeedbackText { get; set; }
        public Nullable<int> AirlineId { get; set; }
        public Nullable<int> ClientId { get; set; }
        public virtual Airlinecompany Airlinecompany { get; set; }
        public virtual Client Client { get; set; }
    }
}
