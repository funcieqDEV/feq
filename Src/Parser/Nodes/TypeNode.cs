namespace Src.AST;
using Src.Lexer;

public class TypeNode : Node
{
    public Token Type { get; set; }

    public TypeNode(Token type)
    {
        Type = type;
    }
}