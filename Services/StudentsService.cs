using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Dtos;
using SchoolWeb.API.Models;
using System.Data;
using System.Linq.Expressions;

namespace SchoolWeb.API.Providers
{
	public class StudentsService : BaseService, IStudentsService
	{
		public StudentsService(): base()
		{ }

		public StudentsService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{ }

		#region Student Details
		public StudentDetailsListDto GetRegisteredStudentDetailsList(Expression<Func<Student, bool>> filter, bool rteOnly)
		{
			List<StudentDetailsDto> students = UnitOfWork.StudentRepository
					.Get(filter: filter, 
						orderBy: stu => stu.OrderBy(s => s.ClassId).ThenBy(s => s.SectionId),
						includes: new List<Expression<Func<Student, object>>>
						{
							stu => stu.Class,
							stu => stu.Section,
							stu => stu.Locality,
							stu => stu.FeesHistories,
							stu => stu.RouteBusStop
						})
					.Select(student => new StudentDetailsDto(student))
					.ToList();

			string title = rteOnly ? "Registered RTE Students Details" : "Registered Students Details";
			return new StudentDetailsListDto(students, title);
		}
		#endregion
	}
}
