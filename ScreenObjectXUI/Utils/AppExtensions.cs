namespace ScreenObjectXUI.Utils
{
	using System;
	using System.Linq;
	using Xamarin.UITest;
	using Xamarin.UITest.Queries;
	using Screens;
	using QueryFunc = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

	public static class AppExtensions
    {
        public static void TapElementContainingText(this IApp app, string substring)
        {
            var rawQuery = string.Format("* {{text CONTAINS '{0}'}}", substring);
            app.Tap(e => e.Raw(rawQuery));
        }

        public static AppResult SingleElement(this IApp app, QueryFunc query)
        {
            return app.Query(query).First();
        }

        public static AppResult[] WaitForElementContainingText(this IApp app, string substring)
        {
            var rawQuery = string.Format("* {{text CONTAINS '{0}'}}", substring);
            return app.WaitForElement(e => e.Raw(rawQuery));
        }

        public static AppQuery ContainsInsensitive(this AppQuery query, string substring)
        {
            var rawQuery = string.Format("* {{text CONTAINS[c] '{0}'}}", substring);
            return query.Raw(rawQuery);
        }

        public static void WaitForAndTap(this IApp app, QueryFunc query)
        {
            app.WaitForElement(query).First();
            app.Tap(query);
        }

        public static void Screenshot(this IApp app, string format, params object[] args)
        {
            app.Screenshot(string.Format(format, args));
        }

		public static bool TraitExists(this IApp app, Trait trait)
		{
			try
			{
				var results = app.WaitForTrait(trait);
				return results.Any();
			}
			catch
			{
				return false;
			}

		}

		public static AppResult[] WaitForTrait(this IApp app, Trait trait, TimeSpan? timeout = null)
		{
			if (timeout == null)
				timeout = TimeSpan.FromSeconds(30);

			var results = app.WaitForElement(trait.Query, "Timed out waiting for this page's trait.", timeout);
			return trait.CheckSubstring ?
				results.Where(e => e.Text.Contains(trait.MatchText)).ToArray()
					: results;
		}
    }
}

