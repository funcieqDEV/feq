namespace Src.CLI;
using Src.Lexer;
using Src.Diagnostics;
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
        Console.WriteLine("  -c <file>      The source file to process");
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
                case "-c":
                    Lexer lexer = new Lexer();
                    // Process the source file
                    var tokens = lexer.Tokenize(new SourceFile(args[1], System.IO.File.ReadAllText(args[1])));
                    foreach (var token in tokens)
                    {
                        Console.WriteLine($"Token: {token.Type}, Value: {token.Value}");
                    }
                    args = args.Skip(2).ToArray(); // Skip the -c and the file name
                    break;
                default:
                    Console.WriteLine($"Unknown option: {arg}");
                    printHelp();
                    return;
            }
        }
    }
}