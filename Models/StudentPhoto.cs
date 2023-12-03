using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models
{
	[Table("StudentPhotos")]
	public class StudentPhoto
	{
		#region ORM
		[Key, ForeignKey("Student")]
		public int StudentId { get; set; }
		public byte[] ImageData { get; set; }
		public string ImageMimeType { get; set; }
		[Required]
		public virtual Student Student { get; set; }
		#endregion
	}
}
