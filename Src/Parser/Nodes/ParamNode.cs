namespace Src.AST;
using Src.Lexer;

public class ParamNode : Node
{
    public Token Name { get; set; }
    public TypeNode Type { get; set; }

    public ParamNode(Token name, TypeNode type)
    {
        Name = name;
        Type = type;
    }
}