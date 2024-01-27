namespace SchoolWeb.API.Dtos.Account
{
	public class UserDto
	{
		public string FullName { get; set; }
		public string Gender { get; set; }
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		public string UserName { get; set; }
		public List<string> AssignedRoles { get; set; }
		public string Password { get; set; }
		public string CreatedOrUpdatedBy { get; set; }

		public UserDto()
		{ }
	}
}
