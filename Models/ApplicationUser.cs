using Microsoft.AspNetCore.Identity;

namespace SchoolWeb.API.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FullName { get; set; }
		public string Gender { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }

		/// <summary>
		/// Default contructor
		/// </summary>
		public ApplicationUser()
		{ }
	}
}
