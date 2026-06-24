namespace Src.AST;
using Src.Lexer;

public class RetNode : Node
{
    public Expr? Value { get; set; }

    public RetNode(Expr? value)
    {
        Value = value;
    }
}