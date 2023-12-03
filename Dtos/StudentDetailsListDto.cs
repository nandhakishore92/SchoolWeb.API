namespace SchoolWeb.API.Dtos
{
	public class StudentDetailsListDto
	{
		public string Title { get; set; }
		public List<StudentDetailsDto> StudentDetailsList { get; set; }
		public StudentDetailsListDto(List<StudentDetailsDto> studentDetailsList, string title)
		{
			StudentDetailsList = studentDetailsList;
			Title = title;
		}
	}
}
