using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Dtos.Account
{
	/// <summary>
	/// This is same as UserDto without username and password, as it is intended to be used for updating user info.
	/// Username and password should not be able to update via update user method.
	/// </summary>
	public class UpdateUserDto
	{
		[Required]
		public string FullName { get; set; }
		[Required]
		public string Gender { get; set; }
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		public string PhoneNumber { get; set; }
		[Required]
		public List<string> AssignedRoles { get; set; }
		public string CreatedOrUpdatedBy { get; set; }

		public UpdateUserDto()
		{ }

		public UpdateUserDto(UserDto userDto)
		{
			FullName = userDto.FullName;
			Gender = userDto.Gender;
			Email = userDto.Email;
			PhoneNumber = userDto.PhoneNumber;
			AssignedRoles = userDto.AssignedRoles;
			CreatedOrUpdatedBy = userDto.CreatedOrUpdatedBy;
		}
	}
}
