namespace SchoolWeb.API.Models
{
    public class ClassFeesArchive
    {
		public int ClassFeesArchiveId { get; set; }
		public int AcademicYearId { get; set; }
		public int ClassId { get; set; }
		public int TuitionFees { get; set; }
		public int SchoolManagementFees { get; set; }
		public int BookFees { get; set; }
		public int ExamFees { get; set; }
		public bool HasSpecialClass { get; set; }
		public virtual Class Class { get; set; }
		public virtual AcademicYear AcademicYear { get; set; }
	}
}