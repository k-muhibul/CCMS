using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Child_Care_Mangement_System.Data.Enumeration;

namespace Child_Care_Mangement_System.Models
{
    public class Child
    {
        [Key]
        public int ChildId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int ParentId { get; set; }
        public int CareCategoryId { get; set; }
        public CareCategory CareCategory { get; set; }
        public User Parent { get; set; }
        public ICollection<ChildHealthLog> ChildHealthLogs { get; set; }
        public ICollection<Bill> Bills { get; set; }
        public ICollection<Diet> Diets { get; set; }
        public ICollection<ChildClockHistory> ChildClockHistories { get; set; }
        public ICollection<ChildMealLog> ChildMealLogs { get; set; }

        private DateTime dob;
        public DateTime DOB
        {
            get { return this.dob; }
            set
            {
                dob = value; 
                DateTime currentDate = DateTime.Now;
                int ageInMonths = (currentDate.Year - value.Year) * 12 + (currentDate.Month - value.Month);
                this.Age = ageInMonths;
                if (ageInMonths <= 18)
                {
                    this.CareCategoryId = (int)CareCategoryType.Infant;
                   
                }
                else if (ageInMonths > 18 && ageInMonths <= 36)
                {
                    this.CareCategoryId = (int)CareCategoryType.Toddler;
                    
                }
                else if (ageInMonths > 36 && ageInMonths <= 60)
                {
                    this.CareCategoryId = (int)CareCategoryType.PreSchool;
                   
                }
                else
                {
                    this.CareCategoryId = (int)CareCategoryType.Unknown;
                   
                }
            }
        }
    }
}
