namespace SchoolWeb.API.Providers
{
	public interface IStudentsProvider: IBaseProvider
	{
		string GetStudent(int studentId);
	}
}
