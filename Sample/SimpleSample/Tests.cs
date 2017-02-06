using NUnit.Framework;
using Xamarin.UITest;

namespace Xablu.ScreenObjectXUI.Samples.SimpleSample
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = new AppManager().StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
        }

        [Test]
        public void Login()
        {
            var loginScreen = new LoginScreen();
            //loginScreen.Login("test","test");
            //crea
        }
    }
}
