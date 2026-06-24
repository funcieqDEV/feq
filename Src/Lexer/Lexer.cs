namespace Src.Lexer;
using Src.Diagnostics;

public class Lexer
{
    int pos_ = 0;
    string input_ = "";

    public Dictionary<string, TokenType> Keywords { get; set; } = new Dictionary<string, TokenType>
    {
        { "if", TokenType.KIf },
        { "else", TokenType.KElse },
        { "for", TokenType.KFor },
        { "ret", TokenType.KRet},
        { "fn", TokenType.KFn },
        { "let", TokenType.KLet },
        { "ext", TokenType.KExt },
        { "continue", TokenType.KContinue },
        { "break", TokenType.KBreak }
    };
    public List<Token> Tokenize(SourceFile sourceFile)
    {
        var tokens = new List<Token>();
        input_ = sourceFile.Content;


        while(!IsAtEnd())
        {
            char c = Peek();
            if (char.IsWhiteSpace(c))
            {
                Consume();
                continue;
            }
            else if (char.IsLetter(c))
            {
                string identifier = "";
                while (char.IsLetterOrDigit(Peek()))
                {
                    identifier += Consume();
                }

                if(Keywords.ContainsKey(identifier))
                {
                    tokens.Add(new Token(Keywords[identifier], identifier));
                }
                else
                {
                    tokens.Add(new Token(TokenType.Identifier, identifier));
                }
            }
            else if (char.IsDigit(c))
            {
                string number = "";
                bool isFloat = false;
                while (char.IsDigit(Peek()))
                {
                    number += Consume();
                }
                if (Peek() == '.')
                {
                    isFloat = true;
                    number += Consume();
                    while (char.IsDigit(Peek()))
                    {
                        number += Consume();
                    }
                }
                tokens.Add(new Token(isFloat ? TokenType.FloatLiteral : TokenType.IntLiteral, number));
            }
            else if (c == '"')
            {
                Consume(); // consume the opening quote
                string str = "";
                while (Peek() != '"' && !IsAtEnd())
                {
                    str += Consume();
                }
                if (IsAtEnd())
                {
                    throw new Exception("Unterminated string literal");
                }
                Consume(); // consume the closing quote
                tokens.Add(new Token(TokenType.StringLiteral, str));
            }
            else if (c == '+')
            {
                Consume();
                tokens.Add(new Token(TokenType.Plus, "+"));
            }
            else if (c == '-')
            {
                Consume();
                if (Peek() == '>')
                {
                    Consume();
                    tokens.Add(new Token(TokenType.Arrow, "->"));
                }
                else
                {
                    tokens.Add(new Token(TokenType.Minus, "-"));
                }
            }
            else if (c == '*')
            {
                Consume();
                tokens.Add(new Token(TokenType.Star, "*"));
            }
            else if (c == '/')
            {
                if(PeekNext() == '/')
                {
                    // This is a comment, consume until the end of the line
                    while (Peek() != '\n' && !IsAtEnd())
                    {
                        Consume();
                    }
                }
                else
                {
                    Consume();
                    tokens.Add(new Token(TokenType.Slash, "/"));
                }
            }
            else if (c == '=')
            {
                Consume();
                if (Peek() == '=')
                {
                    Consume();
                    tokens.Add(new Token(TokenType.DoubleEqual, "=="));
                }
                else
                {
                    tokens.Add(new Token(TokenType.Equal, "="));
                }
            }
            else if (c == '!')
            {
                Consume();
                if (Peek() == '=')
                {
                    Consume();
                    tokens.Add(new Token(TokenType.NotEqual, "!="));
                }
                else
                {
                    throw new Exception($"Unexpected character: {c}");
                }
            }
            else if (c == '%')
            {
                Consume();
                tokens.Add(new Token(TokenType.Modulo, "%"));
            }
            else if (c == ';')
            {
                Consume();
                tokens.Add(new Token(TokenType.SemiColon, ";"));
            }
            else if (c == ':')
            {
                Consume();
                tokens.Add(new Token(TokenType.Colon, ":"));
            }
            else if (c == ',')
            {
                Consume();
                tokens.Add(new Token(TokenType.Comma, ","));
            }
            else if (c == '(')
            {
                Consume();
                tokens.Add(new Token(TokenType.LParen, "("));
            }
            else if (c == ')')
            {
                Consume();
                tokens.Add(new Token(TokenType.RParen, ")"));
            }
            else if (c == '{')
            {
                Consume();
                tokens.Add(new Token(TokenType.LBrace, "{"));
            }
            else if (c == '}')
            {
                Consume();
                tokens.Add(new Token(TokenType.RBrace, "}"));
            }
            else if (c == '[')
            {
                Consume();
                tokens.Add(new Token(TokenType.LBracket, "["));
            }
            else if (c == ']')
            {
                Consume();
                tokens.Add(new Token(TokenType.RBracket, "]"));
            }
            else
            {
                throw new Exception($"Unexpected character: {c}");
            }
        }

        return tokens;
    }


    bool IsAtEnd()
    {
        return pos_ >= input_.Length;
    }

    char Peek()
    {
        if (IsAtEnd())
            return '\0';
        return input_[pos_];
    }

    char PeekNext()
    {
        if (pos_ + 1 >= input_.Length)
            return '\0';
        return input_[pos_ + 1];
    }

    char Consume()
    {
        if (IsAtEnd())
            return '\0';
        return input_[pos_++];
    }
}