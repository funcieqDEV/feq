namespace Src.CLI;

public class CLI
{
    public static string Version = "0.1.0";
    public static string Name = "feq";
    public void printHelp()
    {
        printVersion();
        Console.WriteLine("Usage: feq [options] <file>");
        Console.WriteLine("Options:");
        Console.WriteLine("  -h, --help     Show this help message");
        Console.WriteLine("  -v, --version  Show version information");
    }

    public void printVersion()
    {
        Console.WriteLine($"{Name} v{Version}");
    }

    public void processArgs(string[] args)
    {
        if (args.Length == 0)
        {
            printHelp();
            return;
        }

        foreach (var arg in args)
        {
            switch (arg)
            {
                case "-h":
                case "--help":
                    printHelp();
                    return;
                case "-v":
                case "--version":
                    printVersion();
                    return;
                default:
                    Console.WriteLine($"Unknown option: {arg}");
                    printHelp();
                    return;
            }
        }
    }
}