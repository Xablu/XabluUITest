namespace ScreenObjectXUI
{
    using Interfaces;
    using Xamarin.UITest;
    using Xamarin.UITest.Android;
    using Xamarin.UITest.iOS;

    public abstract class ScreenObjectInitialize : IAppManager
    {
        public static IApp App { get; private set; }

        public static Platform AppPlatform { get; private set; }

        public static bool IsAndroid
        {
            get { return AppPlatform == Platform.Android; }
        }

        public static bool IsIos
        {
            get { return AppPlatform == Platform.iOS; }
        }

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
            return App;
        }

        public abstract AndroidApp ConfigureAndroid(bool clearData);

        public abstract iOSApp ConfigureIOS(bool clearData);
    }
}
