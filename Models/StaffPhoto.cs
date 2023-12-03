using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolWeb.API.Models
{
	[Table("StaffPhotos")]
	public class StaffPhoto
	{
		#region ORM
		[Key, ForeignKey("StaffDetail")]
		public int StaffId { get; set; }
		public byte[] ImageData { get; set; }
		public string ImageMimeType { get; set; }
		[Required]
		public virtual StaffDetail StaffDetail { get; set; }
		#endregion
	}
}
