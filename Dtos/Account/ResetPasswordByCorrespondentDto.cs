using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Account
{
	public class ResetPasswordByCorrespondentDto : ResetPasswordBaseDto
	{
		[Required]
		public string UserName { get; set; }

		public ResetPasswordByCorrespondentDto() : base()
		{ }
	}
}
