using System.Net;
using System.Net.Sockets;
using CcShell;

// You can use print statements as follows for debugging, they'll be visible when running tests.
// Console.WriteLine("Logs from your program will appear here!");
var commandRegistry = new Dictionary<string, IShellCommand>
{
    { "exit", new ExitCommand() }
};

while (true)
{
    Console.Write("$ ");

    try
    {
        var input = Console.ReadLine()?.Split(' ');
        var cmd = input?.FirstOrDefault();
        var opts = input?.Skip(1);

        if (cmd is not null && commandRegistry.TryGetValue(cmd, out var cmdToRun))
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

void HandleInvalidCommand(string? s)
{
    Console.WriteLine($"{s}: command not found");
}