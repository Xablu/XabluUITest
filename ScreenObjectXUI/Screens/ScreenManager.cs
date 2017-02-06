namespace Xablu.ScreenObjectXUI.Screens
{
    public class ScreenManager
    {
        public static TScreen GetScreen<TScreen>()
        {
            return (TScreen)typeof(TScreen).GetMethod("Instance").Invoke(null, null);
        }
    }
}

