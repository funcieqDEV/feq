namespace Src.AST;
using Src.Lexer;

public class ParamNode : Node
{
    public ConstID Name { get; set; }
    public TypeNode Type { get; set; }

    public ParamNode(ConstID name, TypeNode type)
    {
        Name = name;
        Type = type;
    }
}