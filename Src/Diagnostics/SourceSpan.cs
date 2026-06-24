namespace Src.Diagnostics;

public readonly record struct SourceSpan
{
    public SourceLocation Start { get; init; }
    public SourceLocation End { get; init; }
    public SourceFile File { get; init; }

    public SourceSpan(SourceLocation start, SourceLocation end, SourceFile file)
    {
        Start = start;
        End = end;
        File = file;
    }
}