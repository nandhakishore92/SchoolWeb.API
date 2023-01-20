using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Models;

namespace SchoolWeb.API.Providers
{
	public class StudentsService : BaseService, IStudentsService
	{
		public StudentsService(): base()
		{ }

		public StudentsService(IUnitOfWork unitOfWork) : base(unitOfWork)
		{ }

		public string GetStudent(int studentId)
		{
			return UnitOfWork.StudentRepository.GetById(studentId).StudentName;
		}
	}
}
