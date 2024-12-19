using System.Windows.Input;
using LanguageExt;
using LanguageExt.Common;

namespace CcShell;

public class EchoCommand : IShellCommand
{
    public string Execute(IEnumerable<string> args, ShellContext ctx)
    {
        return string.Join(' ', args) + Environment.NewLine;
    }

    public Validation<Error, IEnumerable<string>> ValidateArguments(IEnumerable<string>? args)
    {
        return new Validation.Success<Error, IEnumerable<string>>(args ?? []);
    }
}