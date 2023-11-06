using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class ChildMealLog
    {
        [key]
        public int ChildMealLogId { get; set; }
        public int ChildId { get; set; }
        public int MealId { get; set; }
        public int DietId { get; set; }
        public DateTime Date { get; set; }
        public Child Child { get; set; }
        public Meal Meal { get; set; }
        public Diet Diet { get; set; }
      
    }
}
