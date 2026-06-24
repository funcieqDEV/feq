using Src.CLI;

public class Program
{
    public static void Main(string[] args)
    {
        var cli = new CLI();
        cli.processArgs(args);
    }
}