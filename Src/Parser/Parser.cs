namespace Src.Parser;
using Src.AST;
using Src.Lexer;

public class Parser
{
    private readonly List<Token> _tokens;
    private int _current;

    public Parser(List<Token> tokens)
    {
        _tokens = tokens;
        _current = 0;
    }

    public RootNode Parse()
    {
        var children = new List<Node>();
        while (!Check(TokenType.EOF))
        {
            children.Add(ParseTopNodes());
        }
        return new RootNode(children);
    }

    private Node ParseTopNodes()
    {
        Token cur = Peek();
        return cur.Type switch
        {
            TokenType.KFn => ParseFunctionNode(),
            _ => throw new Exception($"todo: unexpected token {cur.Type}"),
        };
    }

    private FunctionNode ParseFunctionNode()
    {
        Consume(TokenType.KFn, "Expected 'fn' keyword.");
        var name = new ConstID(Consume(TokenType.Identifier, "Expected function name."));
        Consume(TokenType.LParen, "Expected ( after function name");
        var _params = ParseParams();
        TypeNode ty;
        Consume(TokenType.RParen, "Expected ) after arguments");
        if (Check(TokenType.Arrow))
        {
            Consume(TokenType.Arrow);
            ty = ParseTypeNode();
        }else
        {
            ty = new TypeNode(new ConstID(new Token(TokenType.Identifier,"void")));
        }
        Consume(TokenType.LBrace, "Expected { after function signature");
        var body = ParseBody();
        Consume(TokenType.RBrace, "Expected } after function body");
        return new FunctionNode(name,_params,body);
    }

    private ScopeNode ParseBody()
    {
        ScopeNode body = new(new());

        while (!Check(TokenType.RBrace))
        {
            body.Statements.Add(ParseNode());
        }
        return body;
    }

    private Node ParseNode()
    {
        Advance();
        return new ScopeNode(new());
    }


    private List<ParamNode> ParseParams()
    {
        List<ParamNode> _params = new();
        while(!Check(TokenType.RParen)){
            var name = Consume(TokenType.Identifier);
            var type = ParseTypeNode();
            _params.Add(new ParamNode(new ConstID(name),type));
        }
        return _params;
    }

    private TypeNode ParseTypeNode()
    {
        var typeToken = Consume(TokenType.Identifier, "Expected type identifier.");
        var constID = new ConstID(typeToken);
        return new TypeNode(constID);
    }

    private Token Consume(TokenType type, string errorMessage = "")
    {
        if (Check(type))
            return Advance();

        throw new Exception(errorMessage);
    }

    private bool Check(TokenType type)
    {
        if (IsAtEnd())
            return type == TokenType.EOF;
        return Peek().Type == type;
    }

    private Token Advance()
    {
        if (!IsAtEnd())
            _current++;
        return Previous();
    }

    private bool IsAtEnd()
    {
        return Peek().Type == TokenType.EOF;
    }

    private Token Peek()
    {
        return _tokens[_current];
    }

    private Token Previous()
    {
        return _tokens[_current - 1];
    }
}