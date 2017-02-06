namespace Xablu.ScreenObjectXUI.Screens
{
	using System.Linq;
	using QueryFunc = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;
	using Xamarin.UITest.Queries;
	using Utils;
	using Xamarin.UITest;
	using System;
	using Autofac;
	using Xablu.ScreenObjectXUI.Interfaces;

	public abstract class Screen : IScreen
    {
		protected IContainer IocContainer = ScreenObjectInitialize.IocContainer;

		public IApp App => ScreenObjectInitialize.App;
		public abstract Trait Trait { get; }

        protected Screen()
        { }

        /// <summary>
        /// This method should assert that the page we are constructing is actually shown on the screen
        /// The best way for this is waiting for an element that is guaranteed to be visible if the page is active
        /// 
        /// The default implementation waits for the element provided by Trait in each Screen implementatie
        /// For more complex verification, you can override this method
        /// </summary>
		[Obsolete("WaitAndVerifyCurrentScreen is deprecated, please use the TraitExists extension method instead.")]
        protected virtual void WaitAndVerifyCurrentScreen()
        {
            App.WaitForElement(Trait.Query, $"Navigating to {this.GetType().Name} has failed");
        }

        public bool ElementContainsText(QueryFunc query, string text)
        {
            return App.Query(e => query(e).ContainsInsensitive(text)).Any();
        }

        public bool ElementExists(QueryFunc query)
        {
            return App.Query(e => query(e.All())).Any();
        }

        public bool IsElementVisible(QueryFunc query)
        {
            return App.Query(query).Any();
        }

        public AppResult Element(QueryFunc query)
        {
            return App.SingleElement(query);
        }

        public bool ContainsText(string text)
        {
            return App.Query(e => e.ContainsInsensitive(text)).Any();
        }

        public virtual string GetText(QueryFunc query)
        {
            App.WaitForElement(query);
            return App.Query(query).First().Text;
        }

		protected TScreen getScreen<TScreen>()
		{
			return ScreenManager.GetScreen<TScreen>();
		}
    }
}