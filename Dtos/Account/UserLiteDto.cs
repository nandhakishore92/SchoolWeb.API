using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Account
{
	public class UserLiteDto: UserSuperLiteDto
	{
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public UserLiteDto(): base()
		{ }
	}
}
