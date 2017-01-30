using System;
using ScreenObjectXUI.Interfaces;
using Xamarin.UITest;
using Autofac;

namespace ScreenObjectXUI.Utils
{
	public static class ScreenExtensions
	{
		public static TScreen Screen<TScreen>(this IApp app)
			where TScreen : IScreen, new()
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
	}
}
