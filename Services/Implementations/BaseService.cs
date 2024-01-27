using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Services.Interfaces;

namespace SchoolWeb.API.Services.Implementations
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
