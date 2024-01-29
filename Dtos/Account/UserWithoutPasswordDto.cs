using SchoolWeb.API.Models;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Account
{
	public class UserWithoutPasswordDto: UserWithoutUsernameAndPasswordDto
	{
		[Required]
		public string UserName { get; set; }
		public UserWithoutPasswordDto(): base()
		{ }

		public UserWithoutPasswordDto(ApplicationUser user, List<string> roles) 
			: base(user, roles)
		{
			UserName = user.UserName;
		}
	}
}
