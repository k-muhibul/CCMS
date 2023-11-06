using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class CarerClockHistory
    {
        [Key]
        public int CarerClockHistoryId { get; set; }
        public int CarerId { get; set; }
        public int ShiftId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ClockIn { get; set; }
        public DateTime? ClockOut { get; set; }
        public User Carer { get; set; }
        public Shift Shift { get; set; }
    }
}
