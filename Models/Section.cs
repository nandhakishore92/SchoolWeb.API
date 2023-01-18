using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}