namespace CcShell;

public interface IShellCommand
{
    string Execute(IEnumerable<string> args);
    
    bool ValidateArguments(IEnumerable<string>? args);    
}