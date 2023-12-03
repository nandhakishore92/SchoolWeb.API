using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models
{
	public class StaffDetail
	{
		#region ORM
		[Key]
		public int StaffId { get; set; }
		[Required]
		public int StaffEnrollmentId { get; set; }
		[Required]
		public string StaffName { get; set; }
		public string FatherName { get; set; }
		public string MotherName { get; set; }
		[Required]
		public long ContactNo { get; set; }
		public DateTime DateOfBirth { get; set; }
		public DateTime DateOfJoining { get; set; }
		public DateTime? DateOfRelieving { get; set; }
		public string Gender { get; set; }
		public string Address { get; set; }
		public string BloodGroup { get; set; }
		public int LocalityId { get; set; }
		public int RouteBusStopId { get; set; }
		public int StaffRoleId { get; set; }
		public bool IsActive { get; set; }
		public virtual StaffRole Role { get; set; }
		public virtual RouteBusStop RouteBusStop { get; set; }
		public virtual Locality Locality { get; set; }
		public virtual StaffPhoto StaffPhoto { get; set; }
		#endregion
	}
}
