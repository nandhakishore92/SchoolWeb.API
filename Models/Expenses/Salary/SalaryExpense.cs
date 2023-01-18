using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models.Expenses.Salary
{
    public class SalaryExpense: IExpenseItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Expense")]
        public int ExpenseId { get; set; }
        [ForeignKey("Bill")]
        public int BillId { get; set; }
        public string SalaryType { get; set; }
        public string SalaryMonth { get; set; }
        public string SalaryYear { get; set; }
        public int NonTeaching { get; set; }
        public int Teaching { get; set; }
        public int Others { get; set; }
        public string Comments { get; set; }
        public virtual Expense Expense { get; set; }
        public virtual Bill Bill { get; set; }
    }
}