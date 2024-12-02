using CcShell;

var commandRegistry = new Dictionary<string, IShellCommand>();

commandRegistry["echo"] = new EchoCommand();
commandRegistry["exit"] = new ExitCommand();
commandRegistry["type"] = new TypeCommand(commandRegistry);

var shell = new Shell(commandRegistry);
shell.Run();