public static class BK_DBManager
{
    public static string username;
    public static int mana;
    public static int crystal;
    public static int energy;
    public static int maxEnergy;
    public static int level;
    public static float xp;
    public static float maxXp;

    public static bool LoggedIn { get { return username != null; } }

    public static void LogOut()
    {
        username = null;
    }

}
