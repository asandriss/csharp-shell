using LanguageExt;
using LanguageExt.Common;

namespace CcShell;

public class PwdCommand : IShellCommand
{
    public string Execute(IEnumerable<string> args)
    {
        return Directory.GetCurrentDirectory() + Environment.NewLine;
    }

    public Validation<Error, IEnumerable<string>> ValidateArguments(IEnumerable<string>? args)
    {
        return Validation<Error, IEnumerable<string>>.Success(args ?? []);
    }
}