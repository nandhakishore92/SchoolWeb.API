using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models.Expenses.Loan
{
    public class AuxiloExpense : IExpenseItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Expense")]
        public int ExpenseId { get; set; }
        [ForeignKey("Bill")]
        public int BillId { get; set; }
        public string Comments { get; set; }
        public virtual Expense Expense { get; set; }
        public virtual Bill Bill { get; set; }
    }
}