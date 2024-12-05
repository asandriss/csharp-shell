using CcShell.Helper;

namespace CcShell;

public class TypeCommand(Dictionary<string, IShellCommand> registry) : IShellCommand
{
    public string Execute(IEnumerable<string> args)
    {
        var type = args.First();

        if (registry.ContainsKey(type))
            return $"{type} is a shell builtin" + Environment.NewLine;
        var exec = FileSystem.GetExecutableProgram(type);

        if (!string.IsNullOrWhiteSpace(exec))
        {
            return $"{type} is {exec}" + Environment.NewLine;
        }

        return $"{type}: not found" + Environment.NewLine;
    }

    public bool ValidateArguments(IEnumerable<string>? args)
    {
        return args is not null && args.Any();
    }
}
