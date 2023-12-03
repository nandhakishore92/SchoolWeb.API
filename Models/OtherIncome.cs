using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models
{
    public class OtherIncome
    {
		#region ORM
		[Key]
		public int Id { get; set; }
		public string Source { get; set; }
		public int Amount { get; set; }
		public DateTime ReceivedDate { get; set; }
		[ForeignKey("AcademicYear")]
		public int AcademicYearId { get; set; }
		public string Comments { get; set; }
		public bool IsPersonal { get; set; }
		public virtual AcademicYear AcademicYear { get; set; }
		#endregion

		public OtherIncome()
		{

		}
	}
}