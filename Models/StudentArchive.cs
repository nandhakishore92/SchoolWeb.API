using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWeb.API.Models
{
    public class StudentArchive
    {
        #region ORM
        public int StudentArchiveId { get; set; }
        public int AcademicYearId { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public int RouteBusStopId { get; set; }
        public int PreviousYearFees { get; set; }
        public bool IsActive { get; set; }
        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
        public virtual RouteBusStop RouteBusStop { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        #endregion
    }
}