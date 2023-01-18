using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models
{
    public class BusStop
    {
        #region ORM
        public int BusStopId { get; set; }
        [Required]
        public string BusStopName { get; set; }
        public int LocalityId { get; set; }
        public virtual Locality Locality { get; set; }
        public virtual ICollection<RouteBusStop> RouteBustops { get; set; }
        #endregion

        public string FullBusStopName => Locality.LocalityName + "-" + BusStopName;
    }
}