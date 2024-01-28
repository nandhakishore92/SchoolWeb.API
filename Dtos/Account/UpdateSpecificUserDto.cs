namespace SchoolWeb.API.Dtos.Account
{
	public class UpdateSpecificUserDto
	{
		public UserSuperLiteDto UserSuperLiteInfo { get; set; }
		public UpdateUserDto UserDto { get; set; }
		public UpdateSpecificUserDto()
		{ }
	}
}
