using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models
{
	public class StaffRole
	{
		#region ORM
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public string Description { get; set; }
		public bool IsTeaching { get; set; }
		public bool IsContract { get; set; }
		#endregion
	}
}
