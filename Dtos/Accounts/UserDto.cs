using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Accounts
{
	public class UserDto : UserLiteDto
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
	}
}
