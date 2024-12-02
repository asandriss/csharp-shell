namespace CcShell;

public class Shell(Dictionary<string, IShellCommand> commandRegistry)
{
    private readonly Dictionary<string, IShellCommand> _commandRegistry = commandRegistry;

    public void Run()
    {
        while (true)
        {
            Console.Write("$ ");
            var input = Console.ReadLine()?.Split(' ');;
            var cmd = input?.FirstOrDefault();
            var opts = input?.Skip(1);

            try
            {
                if (cmd is not null &&
                    _commandRegistry.TryGetValue(cmd, out var cmdToRun))
                {
                    if (cmdToRun.ValidateArguments(opts))
                        Console.Write(cmdToRun.Execute(opts));
                }
                else
                {
                    HandleInvalidCommand(string.Join(' ', input));
                }
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