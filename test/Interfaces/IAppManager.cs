using System;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.iOS;

namespace ScreenObjectXUI.Interfaces
{
    public interface IAppManager
    {
        IApp StartApp(Platform platform, bool clearData);
        AndroidApp ConfigureAndroid(bool clearData);
        iOSApp ConfigureIOS(bool clearData);
    }
}
