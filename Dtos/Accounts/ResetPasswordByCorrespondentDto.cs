using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Accounts
{
	public class ResetPasswordByCorrespondentDto : ResetPasswordBaseDto
	{
		[Required]
		public string UserName { get; set; }
	}
}
