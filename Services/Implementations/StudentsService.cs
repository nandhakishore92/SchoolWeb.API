using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Dtos;
using SchoolWeb.API.Models;
using SchoolWeb.API.Services.Interfaces;
using System.Data;
using System.Linq.Expressions;

namespace SchoolWeb.API.Services.Implementations
{
    public class StudentsService : BaseService, IStudentsService
    {
        public StudentsService() : base()
        { }

        public StudentsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        { }

        #region Student Details
     //   public async Task<StudentDetailsListDto> GetRegisteredStudentDetailsList(Expression<Func<Student, bool>> filter, bool rteOnly)
     //   {
     //       List<StudentDto> students = (await UnitOfWork.StudentRepository
     //               .GetAsync(filter: filter,
     //                   orderBy: stu => stu.OrderBy(s => s.ClassId).ThenBy(s => s.SectionId),
     //                   includes: new List<Expression<Func<Student, object>>>
     //                   {
     //                       stu => stu.Class,
     //                       stu => stu.Section,
     //                       stu => stu.Locality,
     //                       stu => stu.FeesHistories,
     //                       stu => stu.RouteBusStop
     //                   }))
					//.Select(student => new StudentDto(student))
     //               .ToList();

     //       string title = rteOnly ? "Registered RTE Students Details" : "Registered Students Details";
     //       return new StudentDetailsListDto(students, title);
     //   }
        #endregion
    }
}
