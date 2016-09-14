using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            //this.Affectations = new List<Affectation>();
          //  this.Flights = new List<Flight>();
        }

        public int EmployeeId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Role { get; set; }

        public int Cin { get; set; }

        public float Salaire { get; set; }


        //public virtual ICollection<Affectation> Affectations { get; set; }
        //  public virtual ICollection<Flight> Flights { get; set; }
    }
}
