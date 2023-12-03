using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Dtos;
using SchoolWeb.API.Providers;

namespace SchoolWeb.API.Controllers
{
	public class StudentsController : ControllerBase, IStudentsController
	{
		private readonly IStudentsService m_Service;
		public StudentsController(IStudentsService service)
		{
			m_Service = service;
		}

		#region Student Details
		[HttpGet("{rteOnly}")]
		public StudentDetailsListDto StudentDetails(bool rteOnly = false)
		{
			if (rteOnly)
				return m_Service.GetRegisteredStudentDetailsList(filter: student => student.IsActive && student.IsRte, rteOnly);
			
			return m_Service.GetRegisteredStudentDetailsList(filter: student => student.IsActive, rteOnly);
		}
		#endregion
	}
}
