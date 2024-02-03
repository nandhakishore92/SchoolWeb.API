using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Controllers.Interfaces;
using SchoolWeb.API.Dtos.Accounts;
using SchoolWeb.API.Models;
using SchoolWeb.API.Services.Interfaces;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Controllers.Implementations
{
	[ApiController]
	[Route("/api/[controller]")]
	[Authorize]
	public class AccountsController : BaseController, IAccountsController
	{
		private readonly IAccountsService _service;
		public AccountsController(IAccountsService service)
		{
			_service = service;
		}

		#region Authentication
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
		[HttpPost]
		[Route("users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> Register([FromBody] UserDto userDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			CustomResponse response = await _service.Register(currentUserName, userDto);
			string createdLocation = CreateUrl(nameof(GetUser), nameof(AccountsController), new { id = userDto.UserName });
			return response.ToActionResult(createdLocation);
		}

		[HttpGet]
		[Route("users/{userName}")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<ActionResult<UserWithoutPasswordDto>> GetUser(string userName)
		{
			var user = await _service.GetUser(userName);
			if (user == null)
				return NotFound(userName);

			return Ok(user);
		}
		
		[HttpGet]
		[Route("users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<ActionResult<List<UserWithoutPasswordDto>>> GetUsers()
		{
			var users = await _service.GetUsers();
			return Ok(users);
		}

		[HttpPut]
		[Route("users/current")]
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
		[Route("users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> UpdateSpecificUser([FromBody] UserWithoutPasswordDto updateSpecificUserDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			CustomResponse response = await _service.UpdateUser(currentUserName, updateSpecificUserDto.UserName, updateSpecificUserDto);
			return response.ToActionResult();
		}

		[HttpPut]
		[Route("users/current/password")]
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
		[Route("users/password")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> ResetSpecificUserPassword([FromBody] ResetPasswordByCorrespondentDto passwordDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			var response = await _service.ResetSpecificUserPassword(currentUserName, passwordDto);
			return response.ToActionResult();
		}

		[HttpDelete]
		[Route("users")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> DeleteSpecificUser([FromBody] UserSuperLiteDto userSuperLiteDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			CustomResponse response = await _service.DeleteSpecificUser(currentUserName, userSuperLiteDto.UserName);
			return response.ToActionResult();
		}
		#endregion

		#region Role Management
		[HttpPost]
		[Route("roles")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> CreateRole([FromBody] RoleDto roleDto)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);

			string currentUserName = HttpContext.User.Identity.Name;
			CustomResponse response = await _service.CreateRole(currentUserName, roleDto);
			return response.ToActionResult();
		}
		#endregion
	}
}
