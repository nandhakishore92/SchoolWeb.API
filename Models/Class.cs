using System.Collections.Generic;

namespace SchoolWeb.API.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        public int TuitionFees { get; set; }
        public int SchoolManagementFees { get; set; }
        public int BookFees { get; set; }
        public int ExamFees { get; set; }
        public bool HasSpecialClass { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}