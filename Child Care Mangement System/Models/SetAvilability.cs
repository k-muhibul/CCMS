using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class SetAvilability
    {
        [Key]
        public int Id { get; set; }
        public int CarerId { get; set; }
        public DateTime Date { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public User Carer { get; set; }
    }
}
