using QueryFunc = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ScreenObjectXUI.Samples.DISample
{
	public class LoginScreenIos
		: LoginShared, ILoginScreen
	{
		protected override QueryFunc LoginButton => e => e.Id("loginButtoniOS");
	}
}
