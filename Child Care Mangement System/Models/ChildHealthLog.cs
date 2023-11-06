using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class ChildHealthLog
    {
        [Key]
        public int ChildHealthLogId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }
        public int ChildId { get; set; }
        public Child Child { get; set; }
    }
}
