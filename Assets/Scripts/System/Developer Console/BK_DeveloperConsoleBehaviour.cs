using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class BK_DeveloperConsoleBehaviour : MonoBehaviour
{
    [SerializeField] private string prefix = string.Empty;
    [SerializeField] private BK_ConsoleCommand[] commands = new BK_ConsoleCommand[0];

    [Header("UI")]
    [SerializeField] private GameObject uiCanvas = null;
    [SerializeField] private TMP_InputField inputField = null;

    private float pausedTimeScale;

    private static BK_DeveloperConsoleBehaviour instance;

    private BK_DeveloperConsole developerConsole;
    private BK_DeveloperConsole DeveloperConsole
    {
        get
        {
            if(developerConsole != null) { return developerConsole; }
            return developerConsole = new BK_DeveloperConsole(prefix, commands);
        }
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void Toggle(InputAction.CallbackContext context)
    {
        if(!context.action.triggered) { return; }

        if(uiCanvas.activeSelf)
        {
            Time.timeScale = pausedTimeScale;
            uiCanvas.SetActive(false);
        }
        else
        {
            pausedTimeScale = Time.timeScale;
            Time.timeScale = 0;
            uiCanvas.SetActive(true);
            inputField.ActivateInputField();
        }
    }

    public void ProcessCommad(string inputValue)
    {
        DeveloperConsole.ProcessCommand(inputValue);

        inputField.text = string.Empty;
    }
}
