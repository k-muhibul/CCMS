using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Child_Care_Mangement_System.Data.Enumeration;

namespace Child_Care_Mangement_System.Models
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public DateTime Date { get; set; }
        public BillStatus Status { get; set; }
        public double TotalDue { get; set; }
        public double Price { get; set; }
        public ICollection<ChildClockHistory> ChildClockHistories { get; set; }
        public int? PaymentHistoryId { get; set; }
        public PaymentHistory? PaymentHistory { get; set; }
        public int ChildId { get; set; }
        public Child Child { get; set; }
        public int UserId { get; set; }
        public User Parent { get; set; }
    }
}
