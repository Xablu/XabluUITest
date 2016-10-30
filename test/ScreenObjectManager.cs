using System;
using ScreenObjectXUI.Interfaces;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;

namespace ScreenObjectXUI
{
    public abstract class ScreenObjectManager : IAppManager
    {
        protected static IApp App { get; private set; }

        protected static Platform AppPlatform { get; private set; }

        protected static bool IsAndroid
        {
            get { return AppPlatform == Platform.Android; }
        }

        protected static bool IsIos
        {
            get { return AppPlatform == Platform.iOS; }
        }

        public ScreenObjectManager(IApp app, Platform platform) 
        {
            ScreenObjectManager.App = app;
            ScreenObjectManager.AppPlatform = platform;
        }

        public IApp StartApp(Platform platform, bool clearData)
        {
            if (ScreenObjectManager.AppPlatform == Platform.Android)
            {
                ScreenObjectManager.App = ConfigureAndroid(clearData);
            }
            else
            {
                ScreenObjectManager.App = ConfigureIOS(clearData);
            }
            return ScreenObjectManager.App;
        }

        public abstract AndroidApp ConfigureAndroid(bool clearData);

        public abstract iOSApp ConfigureIOS(bool clearData);
    }
}
