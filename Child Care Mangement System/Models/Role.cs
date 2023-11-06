using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class Role:IdentityRole<int>
    {
        public Role() { }
        public Role(string roleName) : base(roleName) { }
    }
}
