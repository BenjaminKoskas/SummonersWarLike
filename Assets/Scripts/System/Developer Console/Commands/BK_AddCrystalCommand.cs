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

        if (!BK_DBManager.LoggedIn) 
        { 
            Debug.Log("Not Logged in an account");
            return false; 
        }

        if (!GameObject.Find("Player")) 
        {
            Debug.Log("No Player Found");
            return false; 
        }

        BK_Player player = GameObject.Find("Player").GetComponent<BK_Player>();

        player.AddCrystal(value);
        

        return true;
    }
}