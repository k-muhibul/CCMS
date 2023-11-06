using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string ContactNumber { get; set; }
        public ICollection<SetAvilability> Availabilities { get; set; }
        public ICollection<Child> Children { get; set; }
        public ICollection<Shift> Shifts { get; set; }
        public ICollection<CarerClockHistory> CarerClockHistory { get; set; }
        public ICollection<Bill> Bills { get; set; }


    }
}
