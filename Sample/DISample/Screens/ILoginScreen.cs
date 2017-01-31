using ScreenObjectXUI.Interfaces;

namespace ScreenObjectXUI.Samples.DISample
{
	public interface ILoginScreen
		: IScreen
	{
		ILoginScreen Login(string username, string password);
	}
}
