using LanguageExt;
using LanguageExt.Common;

namespace CcShell;

public class CdCommand : IShellCommand
{
    public string Execute(IEnumerable<string> args, ShellContext context)
    {
        context.CurrentDirectory = args.First();
        
        return String.Empty;
    }

    public Validation<Error, IEnumerable<string>> ValidateArguments(IEnumerable<string>? args)
    {
        if (args is null)
            return ValidationExt.Fail("args must passed in\n");

        var @params = args.ToArray();

        if (@params.Count() != 1)
            return ValidationExt.Fail("provide a directory to change to\n");

        var dirToNavigateTo = @params[0];
        return !Directory.Exists(dirToNavigateTo) 
            ? ValidationExt.Fail($"cd: {dirToNavigateTo}: No such file or directory\n") 
            : ValidationExt.Success(@params);
    }
}