using Xablu.ScreenObjectXUI.Screens;
using Xamarin.UITest;

namespace Xablu.ScreenObjectXUI.Interfaces
{
	public interface IScreen
	{
		IApp App { get; }
		Trait Trait { get; }
	}
}
