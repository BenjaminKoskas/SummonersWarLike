using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class BK_Player : MonoBehaviour
{
    public Text manaDisplay;
    public Text crystalDisplay;
    public Text energyDisplay;

    public static BK_Player instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        if (BK_DBManager.username == null && !GetComponent<BK_Login>().autoLog)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        } 
        else 
        {
            GetComponent<BK_Login>().CallLogin();
        }

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
                manaDisplay.text = final + "K";
            } 
        else
            {
                manaDisplay.text = BK_DBManager.mana.ToString();
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
                crystalDisplay.text = final + "K";
            }
        else
        {
            crystalDisplay.text = BK_DBManager.crystal.ToString();
        }
            
        energyDisplay.text = BK_DBManager.energy.ToString() + "/" + BK_DBManager.maxEnergy.ToString();

    }

    public void CallSaveData()
    {
        StartCoroutine(SavePlayerData());
    }

    private void OnApplicationQuit()
    {
        StartCoroutine(SavePlayerData());
    }
    IEnumerator SavePlayerData()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", BK_DBManager.username);
        form.AddField("mana", BK_DBManager.mana);
        form.AddField("crystal", BK_DBManager.crystal);
        form.AddField("energy", BK_DBManager.energy);
        form.AddField("maxenergy", BK_DBManager.maxEnergy);

        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8888/sqlconnect/savedata.php", form);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.downloadHandler.text == "0")
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.Log("Save failed. Error #" + request.downloadHandler.text);
        }

        BK_DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

}
