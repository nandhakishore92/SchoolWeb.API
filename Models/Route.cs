using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models
{
    public class Route
    {
        public int RouteId { get; set; }
        [Required]
        public string RouteName { get; set; }
        [Required]
        public string Driver { get; set; }
        [Required]
        public string Conductor { get; set; }
        public virtual ICollection<RouteBusStop> RouteBustops { get; set; }
    }
}