using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models
{
	public class User
	{
		[Key]
		public string UserName { get; set; }
		public string Password { get; set; }
		public string FullName { get; set; }
		public string Gender { get; set; }
		public string EmailId { get; set; }
		public long ContactNo { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime UpdatedDate { get; set; }
		public string CreatedBy { get; set; }
		public string UpdatedBy { get; set; }
	}
}