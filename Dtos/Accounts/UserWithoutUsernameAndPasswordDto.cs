using SchoolWeb.API.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Accounts
{
	public class UserWithoutUsernameAndPasswordDto
	{
		[Required]
		public string FullName { get; set; }
		[Required]
		public string Gender { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		[Required]
		public List<string> AssignedRoles { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }

		public UserWithoutUsernameAndPasswordDto()
		{ }

		public UserWithoutUsernameAndPasswordDto(ApplicationUser user, List<string> roles)
		{
			FullName = user.FullName;
			Gender = user.Gender;
			Email = user.Email;
			PhoneNumber = user.PhoneNumber;
			AssignedRoles = roles;
			CreatedBy = user.CreatedBy;
			UpdatedBy = user.UpdatedBy;
		}
	}
}
