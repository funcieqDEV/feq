namespace Src.AST;
using Src.Lexer;

public class ConstStr : Expr
{
    public string Value { get; set; }

    public ConstStr(string value)
    {
        Value = value;
    }
}