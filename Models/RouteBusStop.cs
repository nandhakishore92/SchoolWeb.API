namespace SchoolWeb.API.Models
{
    public class RouteBusStop
    {
        public int RouteBusStopId { get; set; }
        public int BusFees { get; set; }
        public int SpecialClassFees { get; set; }
        public int? RouteId { get; set; }
        public int? BusStopId { get; set; }
        public virtual Route Route { get; set; }
        public virtual BusStop BusStop { get; set; }
    }
}