namespace Src.AST;
using Src.Lexer;

public class ConstInt : Expr
{
    public long Value { get; set; }

    public ConstInt(long value)
    {
        Value = value;
    }
}