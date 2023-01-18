using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models
{
    public class Locality
    {
        public int LocalityId { get; set; }
        [Required]
        public string LocalityName { get; set; }
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<BusStop> BusStops { get; set; }

    }
}