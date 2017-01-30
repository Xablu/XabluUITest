using System;
using ScreenObjectXUI.Screens;

namespace ScreenObjectXUI.Samples.SimpleSample
{
    public class LoginScreen : Screen
    {
		public override Trait Trait => new Trait("test");

		public LoginScreen Login(string username, string password)
		{
			// TODO: Put logic to test login functionality.
			throw new NotImplementedException();
		}
    }
}
