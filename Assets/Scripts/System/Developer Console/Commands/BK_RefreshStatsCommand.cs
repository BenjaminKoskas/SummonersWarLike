using UnityEngine;

[CreateAssetMenu(fileName = "New Refresh Command", menuName = "Utilities/DeveloperConsole/Commands/Refresh Command")]
public class BK_RefreshStatsCommand : BK_ConsoleCommand
{
    public override bool Process(string[] args)
    {
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

        //if (args.Length != 1) { return false; }

        /*if (!int.TryParse(args[0], out int value))
        {
            return false;
        }*/

        Debug.Log(BK_DBManager.mana);

        if(BK_DBManager.mana >= 1000000) // check if mana > 1 million and format the text 
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
            player.manaDisplay.text = final + "K";
        } 
        else
        {
            player.manaDisplay.text = BK_DBManager.mana.ToString();
        }

        if (BK_DBManager.crystal >= 1000000) // check if crystal > 1 million and format the text
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
            player.crystalDisplay.text = final + "K";
        }
        else 
        {
            player.crystalDisplay.text = BK_DBManager.crystal.ToString();
        }
        
        player.energyDisplay.text = BK_DBManager.energy.ToString() + "/" + BK_DBManager.maxEnergy.ToString();

        player.nameDisplay.text = BK_DBManager.username.ToUpper();
        
        return true;
    }
}