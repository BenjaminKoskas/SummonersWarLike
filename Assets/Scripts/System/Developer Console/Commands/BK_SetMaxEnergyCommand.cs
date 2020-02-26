using UnityEngine;

[CreateAssetMenu(fileName = "New Add Max Energy Command", menuName = "Utilities/DeveloperConsole/Commands/Max Energy Command")]
public class BK_SetMaxEnergyCommand : BK_ConsoleCommand
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

        BK_DBManager.maxEnergy = value;
        BK_Player.instance.energyDisplay.text = BK_DBManager.energy.ToString() + "/" + BK_DBManager.maxEnergy.ToString();

        return true;
    }
}