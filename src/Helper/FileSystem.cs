namespace CcShell.Helper;

public class FileSystem
{
    public static IEnumerable<string> GetPathLocations()
    {
        var pathStr = Environment.GetEnvironmentVariable("PATH") ?? "";
        var allPaths = pathStr.Split(':');

        foreach (var path in allPaths)
        {
            yield return path;
        }
    }
    
    public static string GetExecutableProgram(string name)
    {
        foreach (var dir in GetPathLocations())
        {
            if (string.IsNullOrWhiteSpace(dir)) continue;
            if (!Directory.Exists(dir)) continue;
            
            foreach (var file in Directory.GetFiles(dir))
            {
                var lastPart = file.Split('/').LastOrDefault();
                if (!string.IsNullOrWhiteSpace(lastPart) && lastPart == name)
                {
                    return file;
                }
            }
        }
        return String.Empty;
    }
}