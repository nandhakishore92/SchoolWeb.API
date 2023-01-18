using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models.Expenses
{
    [Index(nameof(Name), IsUnique = true)]
	public class Expense
    {
        #region ORM
        [Key]
        public int ExpenseId { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        public bool IsPersonal { get; set; }
        public virtual ICollection<ExpenseVendorMapper> ExpenseVendorMappers { get; set; }
        #endregion
    }

    public interface IExpenseItem
    {
        int Id { get; set; }
        int ExpenseId { get; set; }
        int BillId { get; set; }
        string Comments { get; set; }
        Expense Expense { get; set; }
        Bill Bill { get; set; }
    }

    public interface IPeriodicalExpenseItem: IExpenseItem
    {
        DateTime PeriodFrom { get; set; }
        DateTime PeriodTo { get; set; }
    }

    public interface IVehicleExpenseItem: IExpenseItem
    {
        int VehicleId { get; set; }
        Vehicle Vehicle { get; set; }
    }
}