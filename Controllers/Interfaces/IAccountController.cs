using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Dtos.Account;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Controllers.Interfaces
{
	public interface IAccountController
	{
		#region Registration and Authentication
		[HttpPost]
		[Route("register")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> Register([FromBody] UserDto userDto);
		
		[HttpPost]
		[Route("login")]
		[AllowAnonymous]
		Task<IActionResult> Login([FromBody] UserLiteDto userLiteDto);

		[HttpPost]
		[Route("logout")]
		[Authorize]
		Task<IActionResult> Logout();
		#endregion

		#region User Management
		[HttpGet]
		[Route("get-users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> GetUsers();

		[HttpGet]
		[Route("get-user/{userName}")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> GetUser(string userName);

		[HttpPut]
		[Route("update-current-user")]
		[Authorize]
		Task<IActionResult> UpdateCurrentUser([FromBody] UserWithoutUsernameAndPasswordDto userDto);

		[HttpPut]
		[Route("update-specific-user")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> UpdateSpecificUser([FromBody] UserWithoutPasswordDto updateSpecificUserDto);

		[HttpDelete]
		[Route("delete-specific-user")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> DeleteSpecificUser([FromBody] UserSuperLiteDto userSuperLiteDto);

		[HttpPut]
		[Route("reset-specific-user-password")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> ResetSpecificUserPassword([FromBody] ResetPasswordByCorrespondentDto userLiteDto);

		[HttpPut]
		[Route("reset-current-user-password")]
		[Authorize]
		Task<IActionResult> ResetCurrentUserPassword([FromBody] ResetPasswordDto passwordDto);
		#endregion

		#region Role Management
		[HttpPost]
		[Route("create-role")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> CreateRole([FromBody] RoleDto roleDto);
		#endregion
	}
}
