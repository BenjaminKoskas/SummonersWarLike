using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BK_MainMenu : MonoBehaviour
{
    public Button registerButton;
    public Button loginButton;
    public Button playButton;

    public Text playerDisplay;

    void Start()
    {
        if(BK_DBManager.LoggedIn)
        {
            playerDisplay.text = "Player : " + BK_DBManager.username;
        }
        registerButton.interactable = !BK_DBManager.LoggedIn;
        loginButton.interactable = !BK_DBManager.LoggedIn;
        playButton.interactable = BK_DBManager.LoggedIn;
    }

    public void GoToRegister()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToLogin()
    {
        SceneManager.LoadScene(2);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene(3);
    }
}
