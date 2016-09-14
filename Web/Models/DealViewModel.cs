using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    public class DealViewModel

    {  


    /// <summary>
    /// Title
    /// </summary>
    public Boolean Active { get; set; }

    /// <summary>
    /// Description
    /// </summary>
    [Display(Name = "Description")]
    public string Description { get; set; }

    /// <summary>
    /// Out date
    /// </summary>
    [Display(Name = "Date end du deal")]
    public Nullable<System.DateTime> EndDeal { get; set; }


        [Display(Name = "Date Debut du deal")]
        public Nullable<System.DateTime> StartDeal { get; set; }

   
   

        [Display(Name = "Flight")]

        public int? FlightId { get; set; } // ? nullable

        public IEnumerable<SelectListItem> Flights { get; set; }



    }
}
  