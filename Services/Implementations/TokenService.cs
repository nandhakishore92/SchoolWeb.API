using Microsoft.IdentityModel.Tokens;
using SchoolWeb.API.Models;
using SchoolWeb.API.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SchoolWeb.API.Services.Implementations
{
	public class TokenService : ITokenService
	{
		private const int _jwtTokenExpirationMinutes = 30;
		private readonly IConfiguration _configuration;

		public TokenService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public string CreateToken(ApplicationUser user, IEnumerable<string> userRoles)
		{
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Issuer = _configuration["JwtTokenSettings:ValidIssuer"],
				Audience = _configuration["JwtTokenSettings:ValidAudience"],
				Expires = DateTime.UtcNow.AddMinutes(_jwtTokenExpirationMinutes),
				SigningCredentials = CreateSigningCredentials(),
				Subject = CreateClaims(user, userRoles)
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);
			return tokenHandler.WriteToken(token);
		}

		private SigningCredentials CreateSigningCredentials()
		{
			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtTokenSettings:SymmetricSecurityKey"]));
			return new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
		}

		private ClaimsIdentity CreateClaims(ApplicationUser user, IEnumerable<string> userRoles)
		{
			try
			{
				var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};

				foreach (var userRole in userRoles)
					authClaims.Add(new Claim(ClaimTypes.Role, userRole));

				return new ClaimsIdentity(authClaims);
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				throw;
			}
		}
	}
}
