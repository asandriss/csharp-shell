namespace CcShell;

public class TypeCommand(Dictionary<string, IShellCommand> registry) : IShellCommand
{
    public string Execute(IEnumerable<string> args)
    {
        var type = args.FirstOrDefault();

        var result = registry.ContainsKey(type) ?
            $"{type} is a shell builtin" 
            : $"{type} invalid_command";

        return result + Environment.NewLine;
    }

    public bool ValidateArguments(IEnumerable<string>? args)
    {
        return args is not null && args.Any();
    }
}