using SchoolWeb.API.Dtos.Account;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Services.Interfaces
{
	public interface IAccountService: IBaseService
	{
		#region Registration and Authentication
		Task<CustomResponse> Register(UserDto userDto);

		Task<CustomResponse> Login(UserLiteDto userLiteDto);

		Task<CustomResponse> Logout();
		#endregion

		#region User Management
		Task<List<UserDto>> GetUsers();

		Task<UserDto> GetUser(string userName);

		Task<CustomResponse> UpdateUser(string userName, UpdateUserDto userDto);

		Task<CustomResponse> DeleteSpecificUser(UserSuperLiteDto userSuperLiteDto);

		Task<CustomResponse> ResetSpecificUserPassword(UserLiteDto userLiteDto);

		Task<CustomResponse> ResetCurrentUserPassword(PasswordDto passwordDto);
		#endregion

		#region Role Management
		Task<CustomResponse> CreateRole(RoleDto roleDto);
		#endregion
	}
}
