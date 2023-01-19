using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.DataAccessLayer;
using SchoolWeb.API.Models;
using SchoolWeb.API.Providers;

namespace SchoolWeb.API.Controllers
{
	public class StudentsController : ControllerBase
	{
		private readonly IStudentsProvider m_Provider;
		public StudentsController(IStudentsProvider provider)
		{
			m_Provider = provider;
		}

		[HttpGet("{id}")]
		public ActionResult<string> Student(int id)
		{
			return m_Provider.GetStudent(id);
		}
	}
}
