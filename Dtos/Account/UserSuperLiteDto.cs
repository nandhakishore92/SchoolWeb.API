using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Account
{
	public class UserSuperLiteDto
	{
		[Required]
		public string UserName { get; set; }
		public UserSuperLiteDto()
		{ }
	}
}
