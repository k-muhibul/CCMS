using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class EatWellCategory
    {
        [Key]
        public int EatWellCategoryId { get; set; }
        public string Description { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
