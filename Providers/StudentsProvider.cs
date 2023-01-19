using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Models;

namespace SchoolWeb.API.Providers
{
	public class StudentsProvider : BaseProvider, IStudentsProvider
	{
		public StudentsProvider(): base()
		{ }

		public StudentsProvider(IUnitOfWork unitOfWork) : base(unitOfWork)
		{ }

		public string GetStudent(int studentId)
		{
			return UnitOfWork.StudentRepository.GetById(studentId).StudentName;
		}
	}
}
