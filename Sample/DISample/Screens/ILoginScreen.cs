using Xablu.ScreenObjectXUI.Interfaces;

namespace Xablu.ScreenObjectXUI.Samples.DISample
{
	public interface ILoginScreen
		: IScreen
	{
		ILoginScreen Login(string username, string password);
	}
}
