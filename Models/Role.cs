using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models
{
    public class Role
    {
        [Key]
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}