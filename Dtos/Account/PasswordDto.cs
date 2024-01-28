using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Account
{
	public class PasswordDto
	{
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public PasswordDto()
		{ }
	}
}
