using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Models;

namespace SchoolWeb.API.Providers
{
	public class StudentsProvider : BaseProvider
	{
		public StudentsProvider(): base()
		{ }

		public StudentsProvider(IUnitOfWork unitOfWork) : base(unitOfWork)
		{ }

		internal string GetStudent(int studentId)
		{
			return UnitOfWork.StudentRepository.GetById(studentId).StudentName;
		}
	}
}
