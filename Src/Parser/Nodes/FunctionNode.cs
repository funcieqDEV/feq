namespace Src.AST;
using Src.Lexer;

public class FunctionNode : Node
{
    public ConstID Name { get; set; }
    public List<ParamNode> Parameters { get; set; } = new List<ParamNode>();
    public ScopeNode Body { get; set; }

    public FunctionNode(ConstID name, List<ParamNode> parameters, ScopeNode body)
    {
        Name = name;
        Parameters = parameters;
        Body = body;
    }
}