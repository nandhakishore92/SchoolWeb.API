using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Dtos.Account;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Controllers.Interfaces
{
	public interface IAccountController
	{
		#region User Details
		[HttpPost]
		[Route("register")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> Register(UserDto userDto);
		
		[HttpPost]
		[Route("login")]
		[AllowAnonymous]
		Task<IActionResult> Login(string userName, string password);

		[HttpPost]
		[Route("logout")]
		[Authorize]
		Task<IActionResult> Logout();

		[HttpPut]
		[Route("updatecurrentuser")]
		[Authorize]
		Task<IActionResult> UpdateCurrentUser(UserDto userDto);

		[HttpPut]
		[Route("updatespecificuser")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<ActionResult> UpdateSpecificUser(UserDto userDto);

		[HttpDelete]
		[Route("deletespecificuser")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> DeleteSpecificUser(string userName);

		[HttpPut]
		[Route("resetspecificuserpassword")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		Task<IActionResult> ResetSpecificUserPassword(string userName, string password);

		[HttpPut]
		[Route("resetcurrentuserpassword")]
		[Authorize]
		Task<IActionResult> ResetCurrentUserPassword(string password);
		#endregion

		#region Role Details
		Task<IActionResult> CreateRole(RoleDto roleDto);
		#endregion
	}
}
