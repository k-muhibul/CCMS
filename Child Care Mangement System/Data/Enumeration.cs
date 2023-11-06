using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Data
{
    public class Enumeration
    {
        public enum CareCategoryType
        {
            Toddler=2,
            Infant=1,
            PreSchool=3,
            Unknown=0
        }
        public enum EatWellGuideId
        {
            Starch=1,
            FishMeatAndProteins=3,
            FruitsAndVegies=2,
            Dairy=4,
            OilsAndSpreads=5

        }
        public enum MealTypeId
        {
            Breakfast=0,
            Lunch=1,
            Dinner=2,
            Snacks=3
        }
        public enum WeekDay
        {
            Sunday=0,
            Monday=1,
            Tuesday=2,
            Wednesday=3,
            Thursday=4,
            Friday=5
        }

        public enum BillStatus
        {
            Paid=1,
            Due=0
        }
    }
}
