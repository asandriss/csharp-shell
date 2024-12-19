using System.ComponentModel.DataAnnotations;
using LanguageExt;
using LanguageExt.Common;

namespace CcShell;

public class ExitCommand : IShellCommand
{
    public string Execute(IEnumerable<string> args)
    {
        if (args.FirstOrDefault() == "0")
            Environment.Exit(0);
        return "use `exit 0` to exit\n";
    }

    public Validation<Error, IEnumerable<string>> ValidateArguments(IEnumerable<string>? args)
    {
        if (args is null)
            return Validation<Error, IEnumerable<string>>.Fail(Error.New("args must be passed in"));

        var @params = args.ToArray();
        
        return @params.Count() != 1 
           ? Validation<Error, IEnumerable<string>>.Fail(Error.New("you must pass an argument to exit command\n")) 
           : Validation<Error, IEnumerable<string>>.Success(@params);
    }
 
}