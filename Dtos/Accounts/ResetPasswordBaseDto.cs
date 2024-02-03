using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Accounts
{
	public class ResetPasswordBaseDto
	{
		[Required]
		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string ConfirmNewPassword { get; set; }
	}
}
