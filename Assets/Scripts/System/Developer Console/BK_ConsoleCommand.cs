using UnityEngine;

public abstract class BK_ConsoleCommand : ScriptableObject, BK_IConsoleCommand
{
    [SerializeField] private string commandWord = string.Empty;

    public string CommandWord => commandWord;

    public abstract bool Process(string[] args);
}