namespace SchoolWeb.API.Providers
{
	public interface IStudentsService: IBaseService
	{
		string GetStudent(int studentId);
	}
}
