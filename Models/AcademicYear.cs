using System;

namespace SchoolWeb.API.Models
{
    public class AcademicYear
    {
        public int AcademicYearId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string YearString { get; set; }
        public string ShortYearString { get; set; }
        public bool IsCurrentAcademicYear { get; set; }
    }
}