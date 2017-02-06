using Xablu.ScreenObjectXUI.Screens;
using QueryFunc = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Xablu.ScreenObjectXUI.Samples.DISample
{
	public class LoginShared
		: Screen, ILoginScreen
	{
		public override Trait Trait => new Trait("username");

		protected virtual QueryFunc UsernameField => e => e.Id("username");
		protected virtual QueryFunc PasswordField => e => e.Id("password");
		protected virtual QueryFunc LoginButton => e => e.Id("btn_login");

		public virtual ILoginScreen Login(string username, string password)
		{
			App.WaitForElement(UsernameField);
			App.Screenshot("On the Login page");

			App.EnterText(UsernameField, username);
			App.Screenshot("Enter Username");

			App.EnterText(PasswordField, password);
			App.Screenshot("Enter Password");

			App.Tap(LoginButton);
			App.Screenshot("Tap 'Log In'");

			return this;
		}
	}
}
