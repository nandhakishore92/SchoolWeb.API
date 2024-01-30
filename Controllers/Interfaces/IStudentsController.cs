using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Dtos;

namespace SchoolWeb.API.Controllers.Interfaces
{
    public interface IStudentsController
    {
		#region Student Details
		[HttpGet]
		[Route("student-details/{rteOnly}")]
		[Authorize]
		Task<StudentDetailsListDto> StudentDetails(bool rteOnly = false);
        #endregion
    }
}
