using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models.Expenses
{
    public class ExpenseVendorMapper
    {
        [Key]
        public int Id { get; set; }
        public int? ExpenseId { get; set; }
        public int? VendorId { get; set; }
        public bool IsActive { get; set; }
        public virtual Expense Expense { get; set; }
        public virtual Vendor Vendor { get; set; }

        public ExpenseVendorMapper()
        {  }

        public ExpenseVendorMapper(int expenseId, int vendorId, bool isActive)
        {
            ExpenseId = expenseId;
            VendorId = vendorId;
            IsActive = isActive;
        }
    }
}