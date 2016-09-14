using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public partial class Deal
    {
        public int DealId { get; set; }
        public Boolean Active { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> EndDeal { get; set; }

        public Nullable<System.DateTime> StartDeal { get; set; }



        // foreign key
        public int? FlightId { get; set; } // ? nullable

        [ForeignKey("FlightId")]
        public virtual Flight Flight { get; set; }

    
    }


}