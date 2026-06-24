namespace Src.Diagnostics;

public sealed class SourceFile
{
    public string Path { get; set; }
    public string Content { get; set; }

    public SourceFile(string path, string content)
    {
        Path = path;
        Content = content;
    }
}