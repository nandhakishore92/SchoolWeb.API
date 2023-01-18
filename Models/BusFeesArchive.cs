namespace SchoolWeb.API.Models
{
    public class BusFeesArchive
    {
        public int BusFeesArchiveId { get; set; }
        public int AcademicYearId { get; set; }
        public int BusFees { get; set; }
        public int SpecialClassFees { get; set; }
        public int? RouteId { get; set; }
        public int? BusStopId { get; set; }
        public virtual Route Route { get; set; }
        public virtual BusStop BusStop { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
    }
}