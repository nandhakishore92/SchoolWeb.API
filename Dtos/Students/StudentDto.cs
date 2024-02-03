using SchoolWeb.API.Models;

namespace SchoolWeb.API.Dtos.Students
{
    public class StudentDto
    {
        public int? AdmissionNumber { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string Class { get; set; }
        public string Locality { get; set; }
        public long Contact { get; set; }
        public int? PreviousYearFeesBalance { get; set; }
        public int? TotalFeesBalance { get; set; }
        public string Rte { get; set; }
        public StudentDto()
        { }
        public StudentDto(Student student)
        {
            AdmissionNumber = student.AdmissionNumber;
            StudentId = student.StudentId;
            StudentName = student.StudentName;
            FatherName = student.FatherName;
            Class = student.FullClassName;
            Locality = student.Locality.LocalityName;
            Contact = student.ContactNo;
            PreviousYearFeesBalance = student.PreviousYearFeesBalance;
            TotalFeesBalance = student.FeesBalance;
            Rte = student.IsRte ? "Rte" : "NonRte";
        }
        public StudentDto(Student student, bool skipBalance)
        {
            AdmissionNumber = student.AdmissionNumber;
            StudentId = student.StudentId;
            StudentName = student.StudentName;
            FatherName = student.FatherName;
            Class = student.FullClassName;
            Locality = student.Locality.LocalityName;
            Contact = student.ContactNo;
            PreviousYearFeesBalance = student.PreviousYearFeesBalance;
            TotalFeesBalance = student.PreviousYearFeesBalance;
            Rte = student.IsRte ? "Rte" : "NonRte";
        }

        public StudentDto(Student student, bool skipPyb, bool skipBalance)
        {
            AdmissionNumber = student.AdmissionNumber;
            StudentId = student.StudentId;
            StudentName = student.StudentName;
            FatherName = student.FatherName;
            Class = student.FullClassName;
            Locality = student.Locality.LocalityName;
            Contact = student.ContactNo;
            PreviousYearFeesBalance = 0;
            TotalFeesBalance = 0;
            Rte = student.IsRte ? "Rte" : "NonRte";
        }
    }
}
