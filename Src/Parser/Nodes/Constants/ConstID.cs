namespace Src.AST;
using Src.Lexer;

public class ConstID : Expr
{
    public Token ID { get; set; }

    public ConstID(Token id)
    {
        ID = id;
    }
}