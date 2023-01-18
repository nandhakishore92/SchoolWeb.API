using SchoolWeb.API.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models.Expenses
{
    public class Bill
    {
        [Key]
        public int BillId { get; set; }
        public string BillNumber { get; set; }
        public DateTime BillDate { get; set; }
        [ForeignKey("ExpenseVendorMapper")]
        public int ExpenseVendorMapperId { get; set; }
        public BillStatusesEnum BillStatus { get; set; }
        public decimal BillAmount { get; set; }
        public decimal PendingAmount { get; set; }
        public virtual List<BillPaymentHistory> BillPaymentHistories { get; set; }
        public virtual ExpenseVendorMapper ExpenseVendorMapper { get; set; }
    }
}