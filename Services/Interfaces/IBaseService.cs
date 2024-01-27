using SchoolWeb.API.DataAccessLayer;

namespace SchoolWeb.API.Services.Interfaces
{
    public interface IBaseService
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
