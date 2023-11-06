using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Child_Care_Mangement_System.Data.Enumeration;

namespace Child_Care_Mangement_System.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public MealTypeId Type { get; set; }
        public string Description { get; set; }
        public double Carbs { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Sugar { get; set; }
        public double ServingSize { get; set; }
        public double Calorie { get; set; }
        public int EatWellCategoryId { get; set; }
        public EatWellCategory EatWellCategory { get; set; }
        public ICollection<Diet> Diets { get; set; }
    }
}
