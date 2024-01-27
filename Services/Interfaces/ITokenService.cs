using SchoolWeb.API.Models;

namespace SchoolWeb.API.Services.Interfaces
{
	public interface ITokenService
	{
		string CreateToken(ApplicationUser user, IEnumerable<string> userRoles);
	}
}
