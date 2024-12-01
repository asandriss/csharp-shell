namespace CcShell;

public class ExitCommand : IShellCommand
{
    public string Execute(IEnumerable<string> args)
    {
        if (args.FirstOrDefault() == "0")
            Environment.Exit(0);
        return "use `exit 0` to exit\n";
    }

    public bool ValidateArguments(IEnumerable<string>? args)
    {
        return args is not null && args.Count() == 1;
    }
}