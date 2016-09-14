using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class EmpAirline
    {


        public int EmpAirlineId { get; set; }
        public string Address { get; set; }
        public string Contry { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "please enter the FirstName")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "please enter the LastName")]
        public string Lastname { get; set; }
        public string Phone { get; set; }
        [Range(10000000, 99999999, ErrorMessage = "Not a valid CIN")]
        public long CIN { get; set; }

        [EmailAddress(ErrorMessage = "please enter the Email Address")]
        public string Email { get; set; }

        public int? AirlinecompanyId { get; set; }


        public virtual Airlinecompany Airlinecompany { get; set; }
    }
}
