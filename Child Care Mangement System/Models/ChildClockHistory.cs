using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class ChildClockHistory
    {
        [Key]
        public int ChildClockHistoryId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
        public int ChildId { get; set; }
        public int BillId { get; set; }
        public Child Child { get; set; }
        public Bill Bill { get; set; }

    }
}
