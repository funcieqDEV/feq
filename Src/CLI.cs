namespace Src.CLI;
using Src.Lexer;
using Src.Parser;
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

        for (int i = 0; i < args.Length; i++)
        {
            var arg = args[i];
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
                    if (i + 1 >= args.Length)
                    {
                        Console.WriteLine("Error: -c requires a file argument");
                        return;
                    }
                    var filePath = args[++i];
                    Lexer lexer = new Lexer();
                    var content = System.IO.File.ReadAllText(filePath);
                    var tokens = lexer.Tokenize(new SourceFile(filePath, content));
                    // foreach (var token in tokens)
                    // {
                    //     Console.WriteLine($"Token: {token.Type}, Value: {token.Value}");
                    // }
                    Parser parser = new Parser(tokens);
                    var ast = parser.Parse();
                    Console.WriteLine($"AST: {ast.Children.Count} top-level nodes");
                    break;
                default:
                    Console.WriteLine($"Unknown option: {arg}");
                    printHelp();
                    return;
            }
        }
    }
}