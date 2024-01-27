using Microsoft.AspNetCore.Identity;
using SchoolWeb.API.Dtos.Account;
using SchoolWeb.API.Models;
using SchoolWeb.API.Services.Interfaces;

namespace SchoolWeb.API.Services.Implementations
{
	public class AccountService : BaseService, IAccountService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<ApplicationRole> _roleManager;
		private readonly ITokenService _tokenService;
		public AccountService(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager, ITokenService tokenService)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_tokenService = tokenService;
		}

		#region User Details
		public async Task<(int, string)> Register(UserDto userDto)
		{
			var userExists = await _userManager.FindByNameAsync(userDto.UserName);
			if (userExists != null)
				return (0, "User already exists");

			ApplicationUser user = new ApplicationUser()
			{
				Email = userDto.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = userDto.UserName,
				FullName = userDto.FullName,
				Gender = userDto.Gender,
				CreatedBy = userDto.CreatedOrUpdatedBy,
				CreatedDate = DateTime.Now				
			};
			var createUserResult = await _userManager.CreateAsync(user, userDto.Password);
			if (!createUserResult.Succeeded)
				return (0, "User creation failed! Please check user details and try again.");

			userDto.AssignedRoles.ForEach(async role => await _userManager.AddToRoleAsync(user, role));
			return (1, "User created successfully!");
		}

		public async Task<(int, string)> Login(string userName, string password)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user == null)
				return (0, "Invalid username or password!");

			if (!await _userManager.CheckPasswordAsync(user, password))
				return (0, "Invalid username or password!");

			var userRoles = await _userManager.GetRolesAsync(user);
			string token = _tokenService.CreateToken(user, userRoles);
			return (1, token);
		}

		public async Task<(int, string)> Logout()
		{
			throw new NotImplementedException();
		}

		public async Task<(int, string)> UpdateCurrentUser(UserDto userDto)
		{
			var user = await _userManager.FindByNameAsync(userDto.UserName);
			if (user == null)
				return (0, "User does not exist.");

			user.Email = userDto.Email;
			user.FullName = userDto.FullName;
			user.Gender = userDto.Gender;
			user.UpdatedBy = userDto.CreatedOrUpdatedBy;
			user.UpdatedDate = DateTime.Now;
			
			var updateUserResult = await _userManager.UpdateAsync(user);
			if (!updateUserResult.Succeeded)
				return (0, "User update failed! Please check user details and try again.");

			await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
			foreach (var role in userDto.AssignedRoles)
			{
				var result = await _userManager.AddToRoleAsync(user, role);
				if (!result.Succeeded)
				{
					return (0, $"Failed to add role {role} to user {user.UserName}.");
				}
			}
			return (1, "User updated successfully!");
		}

		public async Task<(int, string)> UpdateSpecificUser(UserDto userDto)
		{
			throw new NotImplementedException();
		}

		public async Task<(int, string)> DeleteSpecificUser(string userName)
		{
			throw new NotImplementedException();
		}

		public async Task<(int, string)> ResetCurrentUserPassword(string password)
		{
			throw new NotImplementedException();
		}

		public async Task<(int, string)> ResetSpecificUserPassword(string userName, string password)
		{
			throw new NotImplementedException();
		}
		#endregion

		#region Role Details
		public async Task<(int, string)> CreateRole(RoleDto roleDto)
		{
			if (await _roleManager.RoleExistsAsync(roleDto.Name))
				return (0, "Role already exists!");

			await _roleManager.CreateAsync(new ApplicationRole(roleDto));
			return (1, "Role created successfully!");
		}
		#endregion
	}
}
