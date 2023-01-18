using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models
{
    public class RteIncome
    {
        #region ORM
        [Key]
        public int Id { get; set; }
        public int ExpectedAmount { get; set; }
        public int ReceivedAmount { get; set; }
        public DateTime ReceivedDate { get; set; }
        [ForeignKey("AcademicYear")]
        public int AcademicYearId { get; set; }
        public string Comments { get; set; }
        public virtual AcademicYear AcademicYear { get; set; }
        #endregion

        public RteIncome()
        {

        }
    }
}