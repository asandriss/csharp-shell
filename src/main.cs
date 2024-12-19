using CcShell;

var commandRegistry = new Dictionary<string, IShellCommand>();

commandRegistry["echo"] = new EchoCommand();
commandRegistry["exit"] = new ExitCommand();
commandRegistry["type"] = new TypeCommand(commandRegistry);
commandRegistry["pwd"] = new PwdCommand();
commandRegistry["cd"] = new CdCommand();

var shell = new Shell(commandRegistry);
shell.Run();