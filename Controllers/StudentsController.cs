using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Providers;

namespace SchoolWeb.API.Controllers
{
	public class StudentsController : ControllerBase
	{
		private readonly IStudentsService m_Service;
		public StudentsController(IStudentsService service)
		{
			m_Service = service;
		}

		[HttpGet("{id}")]
		public ActionResult<string> Student(int id)
		{
			return m_Service.GetStudent(id);
		}
	}
}
