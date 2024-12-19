using LanguageExt;
using LanguageExt.Common;

namespace CcShell;

public class PwdCommand : IShellCommand
{
    public string Execute(IEnumerable<string> args, ShellContext context)
    {
        // return Directory.GetCurrentDirectory() + Environment.NewLine;
        return context.CurrentDirectory + Environment.NewLine;
    }

    public Validation<Error, IEnumerable<string>> ValidateArguments(IEnumerable<string>? args)
    {
        return Validation<Error, IEnumerable<string>>.Success(args ?? []);
    }
}