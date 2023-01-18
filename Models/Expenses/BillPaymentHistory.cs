using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models.Expenses
{
    public class BillPaymentHistory
    {
        [Key]
        public int BillPaymentHistoryId { get; set; }
        [ForeignKey("Bill")]
        public int BillId { get; set; }
        public string BillNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PaidAmount { get; set; }
        public string Comments { get; set; }
        public virtual Bill Bill { get; set; }
    }
}