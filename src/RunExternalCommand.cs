using System.Diagnostics;

namespace CcShell;

public class RunExternalCommand
{
    public void RunProgram(string program, IEnumerable<string> args)
    {
        var prc = new Process();
        prc.StartInfo.FileName = program;
        prc.StartInfo.Arguments = string.Join(' ', args);
        prc.StartInfo.UseShellExecute = false;
        prc.StartInfo.RedirectStandardOutput = true;
        prc.Start();
        
        // This might not be the best solution. If the program reads input
        //  this will never end. Need to find a better way
        Console.Write(prc.StandardOutput.ReadToEnd());

        prc.WaitForExit();
    }
}