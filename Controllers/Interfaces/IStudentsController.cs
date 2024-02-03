using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolWeb.API.Dtos.Students;
using SchoolWeb.API.Models;
using SchoolWeb.API.Utilities;

namespace SchoolWeb.API.Controllers.Interfaces
{
	public interface IStudentsController
    {
		#region Add
		[HttpPost]
		[Route("students")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<IActionResult> AddStudent([FromBody] StudentDto studentDto);
		#endregion

		#region Get
		[HttpGet]
		[Route("students/{studentId}")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<ActionResult<StudentDto>> GetStudentDetails(int studentId);

		[HttpGet]
		[Route("students/registered/{rteOnly}")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<ActionResult<List<StudentDto>>> GetRegisteredStudentsDetails(bool rteOnly);

		[HttpGet]
		[Route("students/unregistered/{tcIssued}")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<ActionResult<List<StudentDto>>> GetUnregisteredStudentsDetails(bool tcIssued);

		[HttpGet]
		[Route("students/new-admission-number/{classId}")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<ActionResult<string>> GetNewAdmissionNumber(string classId);

		[HttpGet]
		[Route("students/temp-emis-number")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<ActionResult<string>> GetTempEmisNumber();

		[HttpGet]
		[Route("students/payment-history/{onlyCurrentAcademicYear}")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler)]
		Task<ActionResult<StudentPaymentHistoryDto>> PaymentHistory(bool onlyCurrentAcademicYear);
		#endregion

		#region Edit
		[HttpPut]
		[Route("students")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<IActionResult> EditStudent([FromBody] StudentDto studentDto);

		[HttpPut]
		[Route("students/register/{studentId}")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<IActionResult> RegisterStudent(int studentId);

		[HttpPut]
		[Route("students/unregister/{studentId}")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<IActionResult> UnregisterStudent(int studentId);

		[HttpPut]
		[Route("students/issue-tc/{studentId}")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler + "," + RolesConstant.NewAdmissionHandler)]
		Task<IActionResult> IssueTc(int studentId);
		#endregion

		#region Pay
		[HttpPost]
		[Route("students/pay-fees")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler)]
		Task<IActionResult> PayFees(FeesPaymentDto feesPaymentDto);

		[HttpPost]
		[Route("students/add-discount")]
		[Authorize(Roles = RolesConstant.Correspondent + "," + RolesConstant.FeesHandler)]
		Task<IActionResult> AddDiscount(DiscountDto discountDto);
		#endregion
	}
}
