using UnityEngine;

[CreateAssetMenu(fileName = "New Add Crystal Command", menuName = "Utilities/DeveloperConsole/Commands/Crystal Command")]
public class BK_AddCrystalCommand : BK_ConsoleCommand
{
    public override bool Process(string[] args)
    {
        if (args.Length != 1) { return false; }

        if (!int.TryParse(args[0], out int value))
        {
            return false;
        }

        BK_DBManager.crystal += value;
        if (BK_DBManager.crystal >= 1000000)
        {
            char[] s = BK_DBManager.crystal.ToString().ToCharArray();
            string final = "";
            foreach (char c in s)
            {
                if (final.Length < 1)
                    final += c + ",";
                if (final.Length < 5 && final.Length >= 2)
                    final += c;
            }
            BK_Player.instance.crystalDisplay.text = final + "K";
        }
        else
        {
            BK_Player.instance.crystalDisplay.text = BK_DBManager.crystal.ToString();
        }

        return true;
    }
}