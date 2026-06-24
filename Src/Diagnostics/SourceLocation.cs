namespace Src.Diagnostics;

public readonly record struct SourceLocation
{
    int Line { get; init; }
    int Column { get; init; }
    int Offset { get; init; }
}