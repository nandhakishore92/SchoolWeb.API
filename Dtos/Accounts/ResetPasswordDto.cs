using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Accounts
{
	public class ResetPasswordDto: ResetPasswordBaseDto
	{
		[Required]
		[DataType(DataType.Password)]
		public string CurrentPassword { get; set; }
	}
}
