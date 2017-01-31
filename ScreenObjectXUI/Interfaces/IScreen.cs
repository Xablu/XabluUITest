using ScreenObjectXUI.Screens;
using Xamarin.UITest;

namespace ScreenObjectXUI.Interfaces
{
	public interface IScreen
	{
		IApp App { get; }
		Trait Trait { get; }
	}
}
