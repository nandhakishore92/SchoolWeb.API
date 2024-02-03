using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Controllers.Interfaces;
using SchoolWeb.API.Dtos.Students;
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

		public Task<IActionResult> AddDiscount(DiscountDto discountDto)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> AddStudent([FromBody] StudentDto studentDto)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> EditStudent([FromBody] StudentDto studentDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<string>> GetNewAdmissionNumber(string classId)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<StudentDto>>> GetRegisteredStudentsDetails(bool rteOnly)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<StudentDto>> GetStudentDetails(int studentId)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<string>> GetTempEmisNumber()
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<List<StudentDto>>> GetUnregisteredStudentsDetails(bool tcIssued)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> IssueTc(int studentId)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> PayFees(FeesPaymentDto feesPaymentDto)
		{
			throw new NotImplementedException();
		}

		public Task<ActionResult<StudentPaymentHistoryDto>> PaymentHistory(bool onlyCurrentAcademicYear)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> RegisterStudent(int studentId)
		{
			throw new NotImplementedException();
		}

		public Task<IActionResult> UnregisterStudent(int studentId)
		{
			throw new NotImplementedException();
		}

		//#region Student Details
		//[HttpGet]
		//[Route("student-details/{rteOnly}")]
		//[Authorize]
		//public async Task<StudentDetailsListDto> StudentDetails(bool rteOnly = false)
		//{
		//    if (rteOnly)
		//        return await m_Service.GetRegisteredStudentDetailsList(filter: student => student.IsActive && student.IsRte, rteOnly);

		//    return await m_Service.GetRegisteredStudentDetailsList(filter: student => student.IsActive, rteOnly);
		//}
		//#endregion


	}
}
