using Child_Care_Mangement_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Widgets
{
    public class WidgetService
    {
        public WidgetService()
        {

        }

        public double CalculateCalorieIntake(
   Child child,ChildHealthLog childHealthLog)
        {
            double bmr;

            if (child.Gender.ToLower() == "male")
            {
                bmr = 88.362 + (13.397 * childHealthLog.Weight) + (4.799 * childHealthLog.Height) - (5.677 * (child.Age/12));
            }
            else if (child.Gender.ToLower() == "female")
            {
                bmr = 447.593 + (9.247 * childHealthLog.Weight) + (3.098 * childHealthLog.Height) - (4.330 * (child.Age/12));
            }
            else
            {
                throw new ArgumentException("Gender must be either 'male' or 'female'.");
            }

            // Multiply BMR by the activity level
            double tdee = bmr * 1.55;

            return Math.Round(tdee, 2);
        }



    }
    }
