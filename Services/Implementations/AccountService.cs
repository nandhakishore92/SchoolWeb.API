using Azure.Core;
using Microsoft.AspNetCore.Identity;
using SchoolWeb.API.Dtos.Account;
using SchoolWeb.API.Models;
using SchoolWeb.API.Services.Interfaces;
using SchoolWeb.API.Utilities;
using System;

namespace SchoolWeb.API.Services.Implementations
{
	public class AccountService : BaseService, IAccountService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<ApplicationRole> _roleManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ITokenService _tokenService;
		public AccountService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, SignInManager<ApplicationUser> signInManager, ITokenService tokenService)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
		}

		#region Registration and Authentication
		public async Task<CustomResponse> Register(UserDto userDto)
		{
			var userExists = await _userManager.FindByNameAsync(userDto.UserName);
			if (userExists != null)
				return new CustomResponse(409, "User already exists");

			ApplicationUser user = new ApplicationUser()
			{
				Email = userDto.Email,
				PhoneNumber = userDto.PhoneNumber,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = userDto.UserName,
				FullName = userDto.FullName,
				Gender = userDto.Gender,
				CreatedBy = userDto.CreatedOrUpdatedBy,
				CreatedDate = DateTime.Now				
			};
			var createUserResult = await _userManager.CreateAsync(user, userDto.Password);
			if (!createUserResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", createUserResult.Errors.Select(x => x.Description)));

			var response = await AssignRolesToUser(user, userDto.AssignedRoles);
			if (response.IsBadResponse())
				return response;

			return new CustomResponse(201, "User created successfully!");
		}

		public async Task<CustomResponse> Login(UserLiteDto userLiteDto)
		{
			var user = await _userManager.FindByNameAsync(userLiteDto.UserName);
			if (user == null)
				return new CustomResponse(401, "Invalid credentials!");

			if (!await _userManager.CheckPasswordAsync(user, userLiteDto.Password))
				return new CustomResponse(401, "Invalid credentials!");

			var userRoles = await _userManager.GetRolesAsync(user);
			string token = _tokenService.CreateToken(user, userRoles);
			return new CustomResponse(200, new { Token = token });
		}

		public async Task<CustomResponse> Logout()
		{
			await _signInManager.SignOutAsync();
			return new CustomResponse(200, "Logged out successfully!");
		}
		#endregion

		#region User Management
		public Task<List<UserDto>> GetUsers()
		{
			throw new NotImplementedException();
		}

		public Task<UserDto> GetUser(string userName)
		{
			throw new NotImplementedException();
		}

		public async Task<CustomResponse> UpdateUser(string userName, UpdateUserDto userDto)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user == null)
				return new CustomResponse(404, $"User - {userName} does not exist.");

			user.Email = userDto.Email;
			user.PhoneNumber = userDto.PhoneNumber;
			user.FullName = userDto.FullName;
			user.Gender = userDto.Gender;
			user.UpdatedBy = userDto.CreatedOrUpdatedBy;
			user.UpdatedDate = DateTime.Now;

			var updateUserResult = await _userManager.UpdateAsync(user);
			if (!updateUserResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", updateUserResult.Errors.Select(x => x.Description)));

			await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
			var response = await AssignRolesToUser(user, userDto.AssignedRoles);
			if (response.IsBadResponse())
				return response;

			return new CustomResponse(200, "User updated successfully!");
		}

		public async Task<CustomResponse> DeleteSpecificUser(UserSuperLiteDto userSuperLiteDto)
		{
			throw new NotImplementedException();
		}

		public async Task<CustomResponse> ResetCurrentUserPassword(PasswordDto passwordDto)
		{
			throw new NotImplementedException();
		}

		public async Task<CustomResponse> ResetSpecificUserPassword(UserLiteDto userLiteDto)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Role Management
		public async Task<CustomResponse> CreateRole(RoleDto roleDto)
		{
			if (await _roleManager.RoleExistsAsync(roleDto.Name))
				return new CustomResponse(0, "Role already exists!");

			await _roleManager.CreateAsync(new ApplicationRole(roleDto));
			return new CustomResponse(1, "Role created successfully!");
		}

		private async Task<CustomResponse> AssignRolesToUser(ApplicationUser user, List<string> rolesToBeAssigned)
		{
			foreach (var role in rolesToBeAssigned)
			{
				if (!await _roleManager.RoleExistsAsync(role))
					return new CustomResponse(404, $"Role '{role}' does not exist.");

				var addToRoleResult = await _userManager.AddToRoleAsync(user, role);
				if (!addToRoleResult.Succeeded)
					return new CustomResponse(400, string.Join(", ", addToRoleResult.Errors.Select(x => x.Description)));
			}

			return new CustomResponse(200, $"Roles - '{string.Join(",", rolesToBeAssigned)}' have been assgined to the user '{user.UserName}'");
		}
		#endregion
	}
}
