using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Account
{
	public class ResetPasswordDto: ResetPasswordBaseDto
	{
		[Required]
		[DataType(DataType.Password)]
		public string CurrentPassword { get; set; }

		public ResetPasswordDto(): base()
		{ }
	}
}
