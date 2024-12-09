using CcShell.Helper;

namespace CcShell;

public class Shell(Dictionary<string, IShellCommand> commandRegistry)
{
    public void Run()
    {
        while (true)
        {
            Console.Write("$ ");
            var input = Console.ReadLine()?.Split(' ').ToArray();;
            
            if(input is null || !input.Any()) continue;
            
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
                    if (cmdToRun.ValidateArguments(opts))
                        Console.Write(cmdToRun.Execute(opts));
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
    }

    void HandleInvalidCommand(string? s)
    {
        Console.WriteLine($"{s}: command not found");
    }
}