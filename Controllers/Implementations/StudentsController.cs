using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Controllers.Interfaces;
using SchoolWeb.API.Dtos;
using SchoolWeb.API.Services.Interfaces;

namespace SchoolWeb.API.Controllers.Implementations
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class StudentsController : ControllerBase, IStudentsController
    {
        private readonly IStudentsService m_Service;
        public StudentsController(IStudentsService service)
        {
            m_Service = service;
        }

		#region Student Details
		[HttpGet]
        [Route("student-details/{rteOnly}")]
        [Authorize]
        public async Task<StudentDetailsListDto> StudentDetails(bool rteOnly = false)
        {
            if (rteOnly)
                return await m_Service.GetRegisteredStudentDetailsList(filter: student => student.IsActive && student.IsRte, rteOnly);

            return await m_Service.GetRegisteredStudentDetailsList(filter: student => student.IsActive, rteOnly);
        }
        #endregion
    }
}
