namespace Xablu.ScreenObjectXUI
{
	using System;
	using Autofac;
	using Interfaces;
	using Xamarin.UITest;
	using Xamarin.UITest.Android;
	using Xamarin.UITest.iOS;

	public abstract class ScreenObjectInitialize : IAppManager
    {
		public static IContainer IocContainer { get; private set; }
		public static IApp App { get; private set; }
        public static Platform AppPlatform { get; private set; }
		public static bool IsAndroid => AppPlatform == Platform.Android;
		public static bool IsIos => AppPlatform == Platform.iOS;
        
        public IApp StartApp(Platform platform, bool clearData = true)
        {
            AppPlatform = platform;

            if (AppPlatform == Platform.Android)
            {
                App = ConfigureAndroid(clearData);
            }
            else
            {
                App = ConfigureIOS(clearData);
            }

			ConfigureDependencyInjection();

            return App;
        }

		protected virtual void ConfigureDependencyInjection()
		{
			var builder = new ContainerBuilder();

			RegisterScreens(builder);

			IocContainer = builder.Build();
		}

		private void RegisterScreens(ContainerBuilder builder)
		{
			RegisterSharedScreens(builder);

			switch (AppPlatform)
			{
				case Platform.Android:
					RegisterAndroidScreens(builder);
					break;
				case Platform.iOS:
					RegisterIosScreens(builder);
					break;
				default:
					throw new ArgumentException("Unsupported test platform (should be iOS or Android)");
			}
		}

		protected virtual void RegisterAndroidScreens(ContainerBuilder builder) { }
		protected virtual void RegisterIosScreens(ContainerBuilder builder) { }
		protected virtual void RegisterSharedScreens(ContainerBuilder builder) { }

        public abstract AndroidApp ConfigureAndroid(bool clearData);
		public abstract iOSApp ConfigureIOS(bool clearData);
    }
}
