using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Accounts
{
	public class UserLiteDto: UserSuperLiteDto
	{
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
