using System;
using ScreenObjectXUI.Screens;
using Xamarin.UITest.Queries;

namespace SimpleSample
{
    public class LoginScreen : Screen
    {
        public LoginScreen()
        {
        }

        protected override Func<AppQuery, AppQuery> IsScreenVisibleQuery()
        {
            return e => e.Marked("test");
        }
    }
}
