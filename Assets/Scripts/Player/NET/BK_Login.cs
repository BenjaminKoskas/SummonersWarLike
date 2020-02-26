using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class BK_Login : MonoBehaviour
{
    public InputField nameField;
    public InputField passwordField;

    public Button submitButton;

    public void CallLogin()
    {
        StartCoroutine(LoginPlayer());
    }

    IEnumerator LoginPlayer()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", passwordField.text);

        UnityWebRequest request = UnityWebRequest.Post("http://localhost:8888/sqlconnect/login.php", form);
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        if (request.downloadHandler.text[0] == '0')
        {
            BK_DBManager.username = nameField.text;
            BK_DBManager.mana = int.Parse(request.downloadHandler.text.Split('\t')[1]);
            BK_DBManager.crystal = int.Parse(request.downloadHandler.text.Split('\t')[2]);
            BK_DBManager.energy = int.Parse(request.downloadHandler.text.Split('\t')[3]);
            BK_DBManager.maxEnergy = int.Parse(request.downloadHandler.text.Split('\t')[4]);
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User login failed. Error #" + request.downloadHandler.text);
        }
    }

    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && passwordField.text.Length >= 8);
    }
}
