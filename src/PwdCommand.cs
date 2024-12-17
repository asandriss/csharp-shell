namespace CcShell;

public class PwdCommand : IShellCommand
{
    public string Execute(IEnumerable<string> args)
    {
        return Directory.GetCurrentDirectory() + Environment.NewLine;
    }

    public bool ValidateArguments(IEnumerable<string>? args)
    {
        return true;
    }
}