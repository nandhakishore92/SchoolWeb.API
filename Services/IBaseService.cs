using SchoolWeb.API.DataAccessLayer;

namespace SchoolWeb.API.Providers
{
	public interface IBaseService
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
