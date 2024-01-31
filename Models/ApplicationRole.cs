using Microsoft.AspNetCore.Identity;
using SchoolWeb.API.Dtos.Account;

namespace SchoolWeb.API.Models
{
	public class ApplicationRole : IdentityRole
	{
		public string Description { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedDate { get; set; }
		public ApplicationRole(): base()
		{ }

		public ApplicationRole(RoleDto roleDto, string createdBy) : base(roleDto.Name)
		{
			Description = roleDto.Description;
			CreatedBy = createdBy;
			CreatedDate = DateTime.Now;
		}
	}
}
