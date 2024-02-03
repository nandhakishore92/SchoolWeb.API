using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Accounts
{
	public class UserSuperLiteDto
	{
		[Required]
		public string UserName { get; set; }
	}
}
