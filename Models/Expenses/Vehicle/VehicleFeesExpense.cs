using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models.Expenses.VehicleExpense
{
    public class VehicleFeesExpense: IVehicleExpenseItem, IPeriodicalExpenseItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Expense")]
        public int ExpenseId { get; set; }
        [ForeignKey("Bill")]
        public int BillId { get; set; }
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; }
        public DateTime PeriodFrom { get; set; }
        public DateTime PeriodTo { get; set; }
        public string FeesType { get; set; }
        public string Comments { get; set; }
        public virtual Expense Expense { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}