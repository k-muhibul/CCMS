using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Child_Care_Mangement_System.Data.Enumeration;

namespace Child_Care_Mangement_System.Models
{
    public class Diet
    {
        [Key]
        public int DietId { get; set; }
        public int ChildId { get; set; }
        public double CalorieRequirement { get; set; }
        public WeekDay WeekDay { get; set; }
        public int MealId { get; set; }
        public Meal Meal { get;set; }

    }
}
