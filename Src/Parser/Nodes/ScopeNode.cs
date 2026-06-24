namespace Src.AST;
using Src.Lexer;

public class ScopeNode : Node
{
    public List<Node> Statements { get; set; } = new List<Node>();

    public ScopeNode(List<Node> statements)
    {
        Statements = statements;
    }
}