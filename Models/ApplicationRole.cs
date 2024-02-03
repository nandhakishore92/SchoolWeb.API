using Microsoft.AspNetCore.Identity;

namespace SchoolWeb.API.Models
{
	public class ApplicationRole : IdentityRole
	{
		public string Description { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public ApplicationRole(): base()
		{ }
	}
}
