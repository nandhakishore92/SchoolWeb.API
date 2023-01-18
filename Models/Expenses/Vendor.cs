using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models.Expenses
{
	[Index(nameof(Name), nameof(ComparisonName), IsUnique = true), ]
	public class Vendor
    {
        [Key]
        public int Id { get; set; }
        [StringLength(500)]
        public string Name { get; set; }
        [StringLength(500)]
        public string ComparisonName { get; set; }
        public virtual ICollection<ExpenseVendorMapper> ExpenseVendorMappers { get; set; }
    }
}