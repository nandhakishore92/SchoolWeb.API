using SchoolWeb.API.Dtos;
using SchoolWeb.API.Models;
using System.Linq.Expressions;

namespace SchoolWeb.API.Services.Interfaces
{
    public interface IStudentsService : IBaseService
    {
        #region Student Details
        StudentDetailsListDto GetRegisteredStudentDetailsList(Expression<Func<Student, bool>> filter, bool rteOnly);
        #endregion
    }
}
