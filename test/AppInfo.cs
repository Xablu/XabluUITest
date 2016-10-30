
using Xamarin.UITest;

namespace ScreenObjectXUI
{
    public class AppInfo
    {
        protected static IApp App { get; private set; }

        protected static Platform AppPlatform { get; private set;}

        protected static bool IsAndroid
        {
            get { return AppPlatform == Platform.Android; }
        }

        protected static bool IsIos
        {
            get { return AppPlatform == Platform.iOS; }
        }

        public AppInfo(IApp app, Platform platform)
        {
            AppInfo.App = app;
            AppInfo.AppPlatform = platform;
        }
    }
}
