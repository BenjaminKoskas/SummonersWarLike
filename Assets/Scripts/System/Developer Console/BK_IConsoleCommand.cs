public interface BK_IConsoleCommand
{
    string CommandWord { get; }
    bool Process(string[] args);
}
