using System.Net;
using System.Net.Sockets;
// You can use print statements as follows for debugging, they'll be visible when running tests.
// Console.WriteLine("Logs from your program will appear here!");

while (true)
{
    Console.Write("$ ");

    // Wait for user input
    var input = Console.ReadLine();

    HandleInvalidCommand(input);
}

void HandleInvalidCommand(string? s)
{
    Console.WriteLine($"{s}: command not found");
}