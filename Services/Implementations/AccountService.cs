using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolWeb.API.Controllers.Implementations;
using SchoolWeb.API.Dtos.Account;
using SchoolWeb.API.Models;
using SchoolWeb.API.Services.Interfaces;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Services.Implementations
{
	public class AccountService : BaseService, IAccountService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<ApplicationRole> _roleManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ITokenService _tokenService;
		private readonly ILogger<AccountService> _logger;

		public AccountService(UserManager<ApplicationUser> userManager, 
			RoleManager<ApplicationRole> roleManager, 
			SignInManager<ApplicationUser> signInManager, 
			ITokenService tokenService,
			ILogger<AccountService> logger)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_tokenService = tokenService;
			_logger = logger;
		}

		#region Registration and Authentication
		public async Task<CustomResponse> Register(string currentUserName, UserDto userDto)
		{
			var userExists = await _userManager.FindByNameAsync(userDto.UserName);
			if (userExists != null)
			{
				_logger.LogWarningWithPrefix($"'{currentUserName}' has tried to register an user '{userDto.UserName}' who already exists.");
				return new CustomResponse(409, $"User - {userDto.UserName} already exists");
			}

			ApplicationUser user = new ApplicationUser()
			{
				Email = userDto.Email,
				PhoneNumber = userDto.PhoneNumber,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = userDto.UserName,
				FullName = userDto.FullName,
				Gender = userDto.Gender,
				CreatedBy = currentUserName,
				CreatedDate = DateTime.Now
			};
			var createUserResult = await _userManager.CreateAsync(user, userDto.Password);
			if (!createUserResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", createUserResult.Errors.Select(x => x.Description)));

			var response = await AssignRolesToUser(user, userDto.AssignedRoles);
			if (response.IsBadResponse())
				return response;

			_logger.LogInformationWithPrefix($"'{currentUserName}' has successfully registered a new user '{userDto.UserName}'.");
			return new CustomResponse(201, $"User - {userDto.UserName} created successfully!");
		}

		public async Task<CustomResponse> Login(UserLiteDto userLiteDto)
		{
			var user = await _userManager.FindByNameAsync(userLiteDto.UserName);
			if (user == null)
			{
				_logger.LogCriticalWithPrefix($"Invalid login attempt for username '{userLiteDto.UserName}'. No user found!");
				return new CustomResponse(401, "Invalid credentials!");
			}

			if (!await _userManager.CheckPasswordAsync(user, userLiteDto.Password))
			{
				_logger.LogCriticalWithPrefix($"Invalid login attempt for username '{userLiteDto.UserName}'.");
				return new CustomResponse(401, "Invalid credentials!");
			}

			var userRoles = await _userManager.GetRolesAsync(user);
			string token = _tokenService.CreateToken(user, userRoles);
			_logger.LogInformationWithPrefix($"User '{userLiteDto.UserName}' logged in.");
			return new CustomResponse(200, new { Token = token });
		}

		public async Task<CustomResponse> Logout(string currentUserName)
		{
			await _signInManager.SignOutAsync();
			_logger.LogInformationWithPrefix($"User '{currentUserName}' logged out.");
			return new CustomResponse(200, "Logged out successfully!");
		}
		#endregion

		#region User Management
		public async Task<List<UserWithoutPasswordDto>> GetUsers()
		{
			List<ApplicationUser> appUsers = await _userManager.Users.ToListAsync();
			List<UserWithoutPasswordDto> users = new List<UserWithoutPasswordDto>();
			foreach (var appUser in appUsers)
			{
				List<string> roles = await GetRolesForUser(appUser);
				users.Add(new UserWithoutPasswordDto(appUser, roles));
			}

			return users;
		}

		public async Task<UserWithoutPasswordDto> GetUser(string userName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user == null)
				return null;

			List<string> roles = await GetRolesForUser(user);
			return new UserWithoutPasswordDto(user, roles);
		}

		public async Task<CustomResponse> UpdateUser(string currentUserName, string userName, UserWithoutUsernameAndPasswordDto userDto)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user == null)
				return new CustomResponse(404, $"User - {userName} does not exist.");

			user.Email = userDto.Email;
			user.PhoneNumber = userDto.PhoneNumber;
			user.FullName = userDto.FullName;
			user.Gender = userDto.Gender;
			user.UpdatedBy = currentUserName;
			user.UpdatedDate = DateTime.Now;

			var updateUserResult = await _userManager.UpdateAsync(user);
			if (!updateUserResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", updateUserResult.Errors.Select(x => x.Description)));

			await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
			var response = await AssignRolesToUser(user, userDto.AssignedRoles);
			if (response.IsBadResponse())
				return response;

			return new CustomResponse(200, $"User - {userName} updated successfully!");
		}

		public async Task<CustomResponse> DeleteSpecificUser(string userName)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user == null)
				return new CustomResponse(404, $"User - {userName} does not exist.");

			var deleteUserRolesResult = await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
			if (!deleteUserRolesResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", deleteUserRolesResult.Errors.Select(x => x.Description)));

			var deleteUserResult = await _userManager.DeleteAsync(user);
			if (!deleteUserResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", deleteUserResult.Errors.Select(x => x.Description)));

			return new CustomResponse(200, $"User - {userName} deleted successfully!");
		}

		public async Task<CustomResponse> ResetCurrentUserPassword(string userName, ResetPasswordDto passwordDto)
		{
			var user = await _userManager.FindByNameAsync(userName);
			if (user == null)
				return new CustomResponse(404, $"User - {userName} does not exist.");

			if (passwordDto.NewPassword != passwordDto.ConfirmNewPassword)
				return new CustomResponse(400, "New password and confirm new password do not match.");

			var changePasswordResult = await _userManager.ChangePasswordAsync(user, passwordDto.CurrentPassword, passwordDto.NewPassword);
			if (!changePasswordResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", changePasswordResult.Errors.Select(x => x.Description)));

			user.UpdatedBy = userName;
			user.UpdatedDate = DateTime.Now;
			var updateUserResult = await _userManager.UpdateAsync(user);
			if (!updateUserResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", updateUserResult.Errors.Select(x => x.Description)));

			return new CustomResponse(200, $"Password for user - {userName} changed successfully!");
		}

		public async Task<CustomResponse> ResetSpecificUserPassword(string currentUserName, ResetPasswordByCorrespondentDto passwordDto)
		{
			string userName = passwordDto.UserName;
			var user = await _userManager.FindByNameAsync(userName);
			if (user == null)
				return new CustomResponse(404, $"User - {userName} does not exist.");

			if (passwordDto.NewPassword != passwordDto.ConfirmNewPassword)
				return new CustomResponse(400, "New password and confirm new password do not match.");

			var removePasswordResult = await _userManager.RemovePasswordAsync(user);
			if (!removePasswordResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", removePasswordResult.Errors.Select(x => x.Description)));

			var addPasswordResult = await _userManager.AddPasswordAsync(user, passwordDto.NewPassword);
			if (!addPasswordResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", addPasswordResult.Errors.Select(x => x.Description)));

			user.UpdatedBy = currentUserName;
			user.UpdatedDate = DateTime.Now;
			var updateUserResult = await _userManager.UpdateAsync(user);
			if (!updateUserResult.Succeeded)
				return new CustomResponse(400, string.Join(", ", updateUserResult.Errors.Select(x => x.Description)));

			return new CustomResponse(200, $"Password for user - {userName} reset successfully by correspondent - {currentUserName}!");
		}
		#endregion

		#region Role Management
		public async Task<CustomResponse> CreateRole(RoleDto roleDto)
		{
			if (await _roleManager.RoleExistsAsync(roleDto.Name))
				return new CustomResponse(409, $"Role - {roleDto.Name} already exists!");

			await _roleManager.CreateAsync(new ApplicationRole(roleDto));
			return new CustomResponse(200, $"Role - {roleDto.Name} created successfully!");
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

		private async Task<List<string>> GetRolesForUser(ApplicationUser user)
		{
			var roles = await _userManager.GetRolesAsync(user);
			return roles.ToList();
		}
		#endregion
	}
}
