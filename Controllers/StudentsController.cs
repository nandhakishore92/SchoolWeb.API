using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Models;
using SchoolWeb.API.Providers;

namespace SchoolWeb.API.Controllers
{
	public class StudentsController : BaseController<StudentsProvider>
	{
		public StudentsController(IUnitOfWork unitOfWork)
			: base(unitOfWork)
		{ }

		[HttpGet("{id}")]
		public ActionResult<string> Student(int id)
		{
			return Provider.GetStudent(id);
		}
	}
}
