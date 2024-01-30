using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Controllers.Interfaces;
using SchoolWeb.API.Dtos.Account;
using SchoolWeb.API.Models;
using SchoolWeb.API.Services.Interfaces;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Controllers.Implementations
{
	[ApiController]
	[Route("/api/[controller]")]
	[Authorize]
	public class AccountController : BaseController, IAccountController
	{
		private readonly IAccountService _service;
		public AccountController(IAccountService service)
		{
			_service = service;
		}

		#region Registration and Authentication
		[HttpPost]
		[Route("register")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> Register([FromBody] UserDto userDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			CustomResponse response = await _service.Register(currentUserName, userDto);
			string createdLocation = CreateUrl(nameof(GetUser), nameof(AccountController), new { id = userDto.UserName });
			return response.ToActionResult(createdLocation);
		}

		[HttpPost]
		[Route("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login([FromBody] UserLiteDto userLiteDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			CustomResponse response = await _service.Login(userLiteDto);
			return response.ToActionResult();
		}

		[HttpPost]
		[Route("logout")]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			string currentUserName = HttpContext.User.Identity.Name;
			CustomResponse response = await _service.Logout(currentUserName);
			return response.ToActionResult();
		}
		#endregion

		#region User Management
		[HttpGet]
		[Route("get-users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> GetUsers()
		{
			var users = await _service.GetUsers();
			return Ok(users);
		}

		[HttpGet]
		[Route("get-user/{userName}")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> GetUser(string userName)
		{
			var user = await _service.GetUser(userName);
			if(user == null)
				return NotFound(userName);

			return Ok(user);
		}

		[HttpPut]
		[Route("update-current-user")]
		[Authorize]
		public async Task<IActionResult> UpdateCurrentUser([FromBody] UserWithoutUsernameAndPasswordDto userDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			CustomResponse response = await _service.UpdateUser(currentUserName, currentUserName, userDto);
			return response.ToActionResult();
		}

		[HttpPut]
		[Route("update-specific-user")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> UpdateSpecificUser([FromBody] UserWithoutPasswordDto updateSpecificUserDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			CustomResponse response = await _service.UpdateUser(currentUserName, updateSpecificUserDto.UserName, updateSpecificUserDto);
			return response.ToActionResult();
		}

		[HttpDelete]
		[Route("delete-specific-user")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> DeleteSpecificUser([FromBody] UserSuperLiteDto userSuperLiteDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			CustomResponse response = await _service.DeleteSpecificUser(userSuperLiteDto.UserName);
			return response.ToActionResult();
		}

		[HttpPut]
		[Route("reset-current-user-password")]
		[Authorize]
		public async Task<IActionResult> ResetCurrentUserPassword([FromBody] ResetPasswordDto passwordDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			var response = await _service.ResetCurrentUserPassword(currentUserName, passwordDto);
			return response.ToActionResult();
		}

		[HttpPut]
		[Route("reset-specific-user-password")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> ResetSpecificUserPassword([FromBody] ResetPasswordByCorrespondentDto passwordDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			var response = await _service.ResetSpecificUserPassword(currentUserName, passwordDto);
			return response.ToActionResult();
		}
		#endregion

		#region Role Management
		[HttpPost]
		[Route("create-role")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			CustomResponse response = await _service.CreateRole(roleDto);
			return response.ToActionResult();
		}
		#endregion
	}
}
