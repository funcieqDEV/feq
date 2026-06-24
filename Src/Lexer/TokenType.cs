namespace Src.Lexer;

public enum TokenType
{
    //keyword
    KExt,
    KFn,
    KLet,
    KIf,
    KElse,
    KFor,
    KRet,
    KContinue,
    KBreak,

    //symbols
    SemiColon,
    Colon,
    Comma,
    LParen,
    RParen,
    LBrace,
    RBrace,
    LBracket,
    RBracket,
    Arrow,

    //operators
    Plus,
    Minus,
    Star,
    Slash,
    Equal,
    DoubleEqual,
    NotEqual,
    Modulo,

    //literals
    Identifier,
    IntLiteral,
    StringLiteral,
    FloatLiteral,
    DoubleLiteral,


    //end of file
    EOF
}