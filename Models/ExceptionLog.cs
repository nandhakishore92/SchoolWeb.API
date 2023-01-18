using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolWeb.API.Models
{
    public class ExceptionLog
    {
        [Key]
        public int Id { get; set; }
        public string Message { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string StackTrace { get; set; }
        public DateTime LogTime { get; set; }
    }
}