using SchoolWeb.API.DataAccessLayer;

namespace SchoolWeb.API.Providers
{
	public class BaseService : IBaseService
	{
		private readonly IUnitOfWork m_UnitOfWork;
		public BaseService()
		{ }
		public BaseService(IUnitOfWork unitOfWork)
		{
			m_UnitOfWork = unitOfWork;
		}
		public IUnitOfWork UnitOfWork
		{
			get { return m_UnitOfWork; }
		}
	}
}
