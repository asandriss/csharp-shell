using LanguageExt;
using LanguageExt.Common;

namespace CcShell;

public interface IShellCommand
{
    string Execute(IEnumerable<string> args);
    
    Validation<Error, IEnumerable<string>> ValidateArguments(IEnumerable<string>? args);    
}