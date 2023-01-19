using SchoolWeb.API.DataAccessLayer;

namespace SchoolWeb.API.Providers
{
	public class BaseProvider : IBaseProvider
	{
		private readonly IUnitOfWork m_UnitOfWork;
		public BaseProvider()
		{ }
		public BaseProvider(IUnitOfWork unitOfWork)
		{
			m_UnitOfWork = unitOfWork;
		}
		public IUnitOfWork UnitOfWork
		{
			get { return m_UnitOfWork; }
		}
	}
}
