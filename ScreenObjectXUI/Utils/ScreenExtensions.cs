using System;
using Xablu.ScreenObjectXUI.Interfaces;
using Xamarin.UITest;
using Autofac;

namespace Xablu.ScreenObjectXUI.Utils
{
	public static class ScreenExtensions
	{
		public static TScreen Screen<TScreen>(this IApp app)
			where TScreen : IScreen
		{
			using (var scope = ScreenObjectInitialize.IocContainer.BeginLifetimeScope())
			{
				var screen = scope.Resolve<TScreen>();
				var trait = screen.Trait;

				if (trait == null)
				{
					throw new Exception($"The {typeof(TScreen)} screen doesn't have a trait configured. Please set a trait in the default constructor of the screen.");
				}

				if (app.TraitExists(trait))
				{
					return screen;
				}

				throw new Exception($"The {typeof(TScreen)} screen was not found.");
			}
		}

		public static void Screenshot(this IScreen screen, string title)
		{
			screen.App.Screenshot(title);
		}

		public static void Screenshot(this IScreen screen, string format, params object[] args)
		{
			screen.App.Screenshot(format, args);
		}
	}
}
