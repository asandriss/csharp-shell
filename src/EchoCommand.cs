using System.Windows.Input;

namespace CcShell;

public class EchoCommand : IShellCommand
{
    public string Execute(IEnumerable<string> args)
    {
        return string.Join(' ', args) + Environment.NewLine;
    }

    public bool ValidateArguments(IEnumerable<string>? args)
    {
        return true;
    }
}