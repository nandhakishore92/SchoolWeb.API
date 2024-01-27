using SchoolWeb.API.Dtos.Account;

namespace SchoolWeb.API.Services.Interfaces
{
	public interface IAccountService: IBaseService
	{
		#region User Details
		Task<(int, string)> Register(UserDto userDto);

		Task<(int, string)> Login(string userName, string password);

		Task<(int, string)> Logout();

		Task<(int, string)> UpdateCurrentUser(UserDto userDto);

		Task<(int, string)> UpdateSpecificUser(UserDto userDto);

		Task<(int, string)> DeleteSpecificUser(string userName);

		Task<(int, string)> ResetSpecificUserPassword(string userName, string password);

		Task<(int, string)> ResetCurrentUserPassword(string password);
		#endregion

		#region Role Details
		Task<(int, string)> CreateRole(RoleDto roleDto);
		#endregion
	}
}
