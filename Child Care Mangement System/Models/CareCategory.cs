using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class CareCategory
    {
        [Key]
        public int CareCategoryId { get; set; }
        public string Description { get; set; }
        public ICollection<Child> Children { get; set; }
    }
}
