using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models
{
    public class StudentRegistrationHistory
    {
		#region ORM
		public int StudentRegistrationHistoryId { get; set; }
		public int StudentId { get; set; }
		public int? AdmissionNumber { get; set; }
		[ForeignKey("JoiningClass")]
		public int JoiningClassId { get; set; }
		[ForeignKey("RelievingClass")]
		public int? RelievingClassId { get; set; }
		[ForeignKey("JoiningAcademicYear")]
		public int JoiningAcademicYearId { get; set; }
		[ForeignKey("RelievingAcademicYear")]
		public int? RelievingAcademicYearId { get; set; }
		public DateTime DateOfJoining { get; set; }
		public DateTime? DateOfRelieving { get; set; }
		public bool IsLastActiveRow { get; set; }
		public virtual Class JoiningClass { get; set; }
		public virtual Class RelievingClass { get; set; }
		public virtual AcademicYear JoiningAcademicYear { get; set; }
		public virtual AcademicYear RelievingAcademicYear { get; set; }
		public virtual Student Student { get; set; }
		#endregion

		public StudentRegistrationHistory()
        { }

        public StudentRegistrationHistory(Student student, int joiningClassId, int joiningAcademicYearId)
        {
            StudentId = student.StudentId;
            Student = student;
            JoiningClassId = joiningClassId;
            AdmissionNumber = student.AdmissionNumber;
            DateOfJoining = student.DateOfJoining;
            IsLastActiveRow = true;
            JoiningAcademicYearId = joiningAcademicYearId;
        }
    }
}