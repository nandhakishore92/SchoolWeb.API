using SchoolWeb.API.Dtos.Account;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Services.Interfaces
{
	public interface IAccountService: IBaseService
	{
		#region Registration and Authentication
		Task<CustomResponse> Register(string currentUserName, UserDto userDto);

		Task<CustomResponse> Login(UserLiteDto userLiteDto);

		Task<CustomResponse> Logout(string currentUserName);
		#endregion

		#region User Management
		Task<List<UserWithoutPasswordDto>> GetUsers();

		Task<UserWithoutPasswordDto> GetUser(string userName);

		Task<CustomResponse> UpdateUser(string currentUserName, string userName, UserWithoutUsernameAndPasswordDto userDto);

		Task<CustomResponse> DeleteSpecificUser(string userName);

		Task<CustomResponse> ResetSpecificUserPassword(string currentUserName, ResetPasswordByCorrespondentDto passwordDto);

		Task<CustomResponse> ResetCurrentUserPassword(string userName, ResetPasswordDto passwordDto);
		#endregion

		#region Role Management
		Task<CustomResponse> CreateRole(RoleDto roleDto);
		#endregion
	}
}
