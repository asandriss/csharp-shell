using CcShell.Helper;
using LanguageExt;
using LanguageExt.Common;

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

    public Validation<Error, IEnumerable<string>> ValidateArguments(IEnumerable<string>? args)
    {
        if (args is null)
            return Validation<Error, IEnumerable<string>>.Fail(Error.New("args must be passed in"));

        var @params = args.ToArray();
        
        return @params.Count() != 1 
           ? Validation<Error, IEnumerable<string>>.Fail(Error.New("provide type name to check")) 
           : Validation<Error, IEnumerable<string>>.Success(@params);
    }
}
