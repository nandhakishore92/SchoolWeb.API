using SchoolWeb.API.Dtos.Accounts;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Services.Interfaces
{
	public interface IAccountsService: IBaseService
	{
		#region Authentication
		Task<CustomResponse> Login(UserLiteDto userLiteDto);

		Task<CustomResponse> Logout(string currentUserName);
		#endregion

		#region User Management
		Task<CustomResponse> Register(string currentUserName, UserDto userDto);

		Task<UserWithoutPasswordDto> GetUser(string userName);
		
		Task<List<UserWithoutPasswordDto>> GetUsers();

		Task<CustomResponse> UpdateUser(string currentUserName, string userName, UserWithoutUsernameAndPasswordDto userDto);

		Task<CustomResponse> ResetCurrentUserPassword(string userName, ResetPasswordDto passwordDto);
		
		Task<CustomResponse> ResetSpecificUserPassword(string currentUserName, ResetPasswordByCorrespondentDto passwordDto);

		Task<CustomResponse> DeleteSpecificUser(string currentUserName, string userName);
		#endregion

		#region Role Management
		Task<CustomResponse> CreateRole(string currentUserName, RoleDto roleDto);
		#endregion
	}
}
