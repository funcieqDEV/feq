namespace Src.AST;
using Src.Lexer;

public class RootNode : Node
{
    public List<Node> Children { get; set; }

    public RootNode(List<Node> children)
    {
        Children = children;
    }
}