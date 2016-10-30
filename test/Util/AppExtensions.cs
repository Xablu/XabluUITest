using System;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;
using QueryFunc = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ScreenObjectXUI.Utils
{
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

        /// <summary>
        /// Contains case insensitive.
        /// </summary>
        /// <returns>The c.</returns>
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

    }
}

