using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Dtos.Accounts;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Controllers.Interfaces
{
	public interface IAccountsController
	{
		#region Authentication
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
		[HttpPost]
		[Route("users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> Register([FromBody] UserDto userDto);

		[HttpGet]
		[Route("users/{userName}")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<ActionResult<UserWithoutPasswordDto>> GetUser(string userName);

		[HttpGet]
		[Route("users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<ActionResult<List<UserWithoutPasswordDto>>> GetUsers();

		[HttpPut]
		[Route("users/current")]
		[Authorize]
		Task<IActionResult> UpdateCurrentUser([FromBody] UserWithoutUsernameAndPasswordDto userDto);

		[HttpPut]
		[Route("users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> UpdateSpecificUser([FromBody] UserWithoutPasswordDto updateSpecificUserDto);

		[HttpPut]
		[Route("users/current/password")]
		[Authorize]
		Task<IActionResult> ResetCurrentUserPassword([FromBody] ResetPasswordDto passwordDto);

		[HttpPut]
		[Route("users/password")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> ResetSpecificUserPassword([FromBody] ResetPasswordByCorrespondentDto userLiteDto);

		[HttpDelete]
		[Route("users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> DeleteSpecificUser([FromBody] UserSuperLiteDto userSuperLiteDto);
		#endregion

		#region Role Management
		[HttpPost]
		[Route("roles")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> CreateRole([FromBody] RoleDto roleDto);
		#endregion
	}
}
