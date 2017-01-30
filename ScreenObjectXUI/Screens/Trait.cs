using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace ScreenObjectXUI.Screens
{
	public class Trait
	{
		public Query Query { get; private set; }
		public bool CheckSubstring { get; private set; }
		public string MatchText { get; private set; }

		public Trait(Query query)
		{
			Query = query;
			CheckSubstring = false;
		}

		public Trait(Query query, string substringToCheck)
			: this(query)
		{
			CheckSubstring = true;
			MatchText = substringToCheck;
		}

		public Trait(string marked) : this(e => e.Marked(marked))
		{

		}

		public Trait(string marked, string substring) : this(e => e.Marked(marked), substring)
		{

		}
	}
}
