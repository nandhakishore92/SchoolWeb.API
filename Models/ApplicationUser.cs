﻿using Microsoft.AspNetCore.Identity;
using SchoolWeb.API.Dtos.Account;

namespace SchoolWeb.API.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string FullName { get; set; }
		public string Gender { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public string CreatedBy { get; set; }
		public string? UpdatedBy { get; set; }

		/// <summary>
		/// Default contructor
		/// </summary>
		public ApplicationUser()
		{ }

		/// <summary>
		/// For registering a new user
		/// </summary>
		/// <param name="userDto"></param>
		public ApplicationUser(UserDto userDto)
		{
			FullName = userDto.FullName;
			Gender = userDto.Gender;
			Email = userDto.Email;
			PhoneNumber = userDto.PhoneNumber;
			UserName = userDto.UserName;
			CreatedDate = DateTime.Now;
			CreatedBy = userDto.CreatedOrUpdatedBy;
		}
	}
}
