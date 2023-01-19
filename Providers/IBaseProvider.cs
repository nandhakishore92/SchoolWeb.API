using SchoolWeb.API.DataAccessLayer;

namespace SchoolWeb.API.Providers
{
	public interface IBaseProvider
	{
		IUnitOfWork UnitOfWork { get; }
	}
}
