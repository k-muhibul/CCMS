using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Child_Care_Mangement_System.Models
{
    public class PaymentHistory
    {
        [Key]
        public int PaymentHistoryId { get; set; }
        public int BillId { get; set; }
        public int ChildId { get; set; }
        public int ParentId { get; set; }
        public DateTime Date { get; set; }
        public Child Child { get; set; }
        public User Parent { get; set; }
        public Bill Bill { get; set; }
    }
}
