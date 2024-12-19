using CcShell.Helper;

namespace CcShell;

public class Shell(Dictionary<string, IShellCommand> commandRegistry)
{
    private ShellContext _context = new ShellContext();
    public void Run()
    {
        while (true)
        {
            Console.Write("$ ");
            var input = Console.ReadLine()?.Split(' ').ToArray();

            if(input is null || input.Length == 0) continue;
            
            var cmd = input.FirstOrDefault();
            if (string.IsNullOrWhiteSpace(cmd))
            {
                continue; // just ignore empty input and reprint the prompt 
            }

            var opts = input.Skip(1).ToArray();

            try
            {
                if (commandRegistry.TryGetValue(cmd, out var cmdToRun))
                {
                    var result = cmdToRun.ValidateArguments(opts);

                    var message = result.Match(
                        validArgs => cmdToRun.Execute(validArgs, _context),
                        err => err.Message
                    );
                    
                    Console.Write(message);
                    
                    continue;
                }

                var program = FileSystem.GetExecutableProgram(cmd);
                if (!string.IsNullOrWhiteSpace(program))
                {
                    (new RunExternalCommand()).RunProgram(program, opts);
                    continue;
                }

                HandleInvalidCommand(string.Join(' ', input));
            }
            catch (Exception ex)
            {
                HandleInvalidCommand(ex.Message);
            }
        }
        // ReSharper disable once FunctionNeverReturns
        //  The graceful exit is handled inside the Exit command
    }

    void HandleInvalidCommand(string? s) => Console.WriteLine($"{s}: command not found");
}