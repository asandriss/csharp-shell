namespace CcShell;

public class TypeCommand(Dictionary<string, IShellCommand> registry) : IShellCommand
{
    public string Execute(IEnumerable<string> args)
    {
        var type = args.FirstOrDefault();

        string result;
        if (registry.ContainsKey(type))
            return $"{type} is a shell builtin" + Environment.NewLine;
        var exec = GetExecutableProgram(type);

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

    private static string GetExecutableProgram(string name)
    {
        foreach (var dir in GetPathLocations())
        {
            if (string.IsNullOrWhiteSpace(dir)) continue;
            if (!Directory.Exists(dir)) continue;
            
            foreach (var file in Directory.GetFiles(dir))
            {
                var lastPart = file.Split('/').LastOrDefault();
                if (!string.IsNullOrWhiteSpace(lastPart) && lastPart == name)
                {
                    return file;
                }
            }
        }
        return String.Empty;
    }

    private static IEnumerable<string> GetPathLocations()
    {
        var pathStr = Environment.GetEnvironmentVariable("PATH") ?? "";
        var allPaths = pathStr.Split(':');

        foreach (var path in allPaths)
        {
            yield return path;
        }
    }
}