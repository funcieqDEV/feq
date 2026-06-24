namespace Src.Lexer;
using Src.Diagnostics;
public class Token
{
    public TokenType Type { get; set; }
    public string Value { get; set; }
    public SourceSpan Span { get; set; }

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value;
    }
}