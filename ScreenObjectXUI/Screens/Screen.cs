namespace ScreenObjectXUI.Screens
{
    using System.Linq;
    using QueryFunc = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
    using Xamarin.UITest.Queries;
    using Utils;
    using Xamarin.UITest;

    public abstract class Screen
    {
        protected IApp app = ScreenObjectInitialize.App;

        public Screen()
        {
            waitAndVerifyCurrentScreen();
        }

        /// <summary>
        /// Return a <c>Func<AppQuery, AppQuery></c> that marks the element which, if found, indicates this screen is currently visible in the app
        /// </summary>
        /// <returns><c>true</c> if this instance is screen visible query; otherwise, <c>false</c>.</returns>
        protected abstract QueryFunc IsScreenVisibleQuery();


        /// <summary>
        /// This method should assert that the page we are constructing is actually shown on the screen
        /// The best way for this is waiting for an element that is guaranteed to be visible if the page is active
        /// 
        /// The default implementation waits for the element provided by IsSchermZichtbaarQuery in each Screen implementatie
        /// For more complex verification, you can override this method
        /// </summary>
        protected virtual void waitAndVerifyCurrentScreen()
        {
            app.WaitForElement(IsScreenVisibleQuery(), $"Navigating to {this.GetType().Name} has failed");
        }

        public bool ElementContainsText(QueryFunc query, string text)
        {
            return app.Query(e => query(e).ContainsInsensitive(text)).Any();
        }

        public bool ElementExists(QueryFunc query)
        {
            return app.Query(e => query(e.All())).Any();
        }

        public bool IsElementVisible(QueryFunc query)
        {
            return app.Query(query).Any();
        }

        public AppResult Element(QueryFunc query)
        {
            return app.SingleElement(query);
        }

        public bool ContainsText(string text)
        {
            return app.Query(e => e.ContainsInsensitive(text)).Any();
        }

        public virtual string GetText(QueryFunc query)
        {
            app.WaitForElement(query);
            return app.Query(query).First().Text;
        }

		protected TScreen getScreen<TScreen>()
		{
			return ScreenManager.GetScreen<TScreen>();
		}
    }
}