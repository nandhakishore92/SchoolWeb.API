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
	public class AccountController : ControllerBase, IAccountController
	{
		private readonly IAccountService _service;
		public AccountController(IAccountService service)
		{
			_service = service;
		}

		#region User Details
		[HttpPost]
		[Route("register")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> Register(UserDto userDto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest("Invalid inputs");

				var (status, message) = await _service.Register(userDto);
				if (status == 0)
					return BadRequest(message);

				return CreatedAtAction(nameof(Register), new { id = userDto.UserName }, null);
			}
			catch (Exception ex)
			{
				//_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		[Route("login")]
		[AllowAnonymous]
		public async Task<IActionResult> Login(string userName, string password)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest("Invalid payload");

				var (status, message) = await _service.Login(userName, password);
				if (status == 0)
					return BadRequest(message);

				return Ok(message);
			}
			catch (Exception ex)
			{
				//_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPost]
		[Route("logout")]
		[Authorize]
		public async Task<IActionResult> Logout()
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		[Route("updatecurrentuser")]
		[Authorize]
		public async Task<IActionResult> UpdateCurrentUser(UserDto userDto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest("Invalid payload");

				var (status, message) = await _service.UpdateCurrentUser(userDto);
				if (status == 0)
					return BadRequest(message);

				return Ok(message);
			}
			catch (Exception ex)
			{
				//_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}

		[HttpPut]
		[Route("updatespecificuser")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<ActionResult> UpdateSpecificUser(UserDto userDto)
		{
			throw new NotImplementedException();
		}

		[HttpDelete]
		[Route("deletespecificuser")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> DeleteSpecificUser(string userName)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		[Route("resetcurrentuserpassword")]
		[Authorize]
		public async Task<IActionResult> ResetCurrentUserPassword(string password)
		{
			throw new NotImplementedException();
		}

		[HttpPut]
		[Route("resetspecificuserpassword")]
		[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> ResetSpecificUserPassword(string userName, string password)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest("Invalid payload");

				var (status, message) = await _service.ResetSpecificUserPassword(userName, password);
				if (status == 0)
					return BadRequest(message);

				return Ok(message);
			}
			catch (Exception ex)
			{
				//_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		#endregion

		#region Role Details
		[HttpPost]
		[Route("createrole")]
		[AllowAnonymous]
		//[Authorize(Roles = RolesConstant.Correspondent)]
		public async Task<IActionResult> CreateRole(RoleDto roleDto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest("Invalid payload");

				var (status, message) = await _service.CreateRole(roleDto);
				if (status == 0)
					return BadRequest(message);

				return CreatedAtAction(nameof(CreateRole), roleDto);
			}
			catch (Exception ex)
			{
				//_logger.LogError(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
			}
		}
		#endregion
	}
}
