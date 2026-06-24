namespace Src.AST;
using Src.Lexer;

public class TypeNode : Node
{
    public ConstID Type { get; set; }

    public TypeNode(ConstID type)
    {
        Type = type;
    }
}