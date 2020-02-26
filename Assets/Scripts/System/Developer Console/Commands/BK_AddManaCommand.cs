using UnityEngine;

[CreateAssetMenu(fileName = "New Add Mana Command", menuName = "Utilities/DeveloperConsole/Commands/Mana Command")]
public class BK_AddManaCommand : BK_ConsoleCommand
{
    public override bool Process(string[] args)
    {
        if (!BK_DBManager.LoggedIn) 
        { 
            Debug.Log("Not Logged in an account");
            return false; 
        }

        if (args.Length != 1) { return false; }

        if (!int.TryParse(args[0], out int value))
        {
            return false;
        }

        BK_DBManager.mana += value;
        if (BK_DBManager.mana >= 1000000)
        {
            char[] s = BK_DBManager.mana.ToString().ToCharArray();
            string final = "";
            foreach (char c in s)
            {
                if (final.Length < 1)
                    final += c + ",";
                if (final.Length < 5 && final.Length >= 2)
                    final += c;
            }
            BK_Player.instance.manaDisplay.text = final + "K";
        }
        else
        {
            BK_Player.instance.manaDisplay.text = BK_DBManager.mana.ToString();
        }

        return true;
    }
}