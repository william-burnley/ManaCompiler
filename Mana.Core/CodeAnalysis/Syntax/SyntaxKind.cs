namespace Mana.Core.CodeAnalysis.Syntax
{
    public enum SyntaxKind
    {
        // General Tokens
        InvalidToken,
        EndOfFile,
        WhiteSpace,
        Number,
        String,
        Identifier,

        // Delimiter Tokens
        OpenSquareBracket,
        CloseSquareBracket,
        OpenCurlyBrace,
        CloseCurlyBrace,
        OpenParenthesis,
        CloseParenthesis,
        Dot,
        Range, // Represents '..' in range contexts
        Semicolon,
        Colon,
        QuestionMark,
        Comma,

        // Operator Tokens
        Assignment,
        Equality, // ==
        Negation,  // !
        Inequality, // !=
        LessThan, // <
        LessThanOrEqual, // <=
        GreaterThan, // >
        GreaterThanOrEqual, // >=
        Disjunction, // ||
        Conjunction, // &&
        Increment, // ++
        Decrement, // --
        AddAssign, // +=
        SubtractAssign, // -=
        MultiplyAssign, // *=
        DivideAssign, // /=
        Plus, // +
        Minus, // -
        Divide, // /
        Multiply, // *
        Modulus, // %

        // Keywords
        FalseKeyword,
        TrueKeyword,

        // Expressions
        LiteralExpression,
        NameExpression,
        NumberExpression,
        UnaryExpression, // Represents expressions with unary operators (e.g., -a, !b)
        BinaryExpression, // Represents expressions with binary operators (e.g., a + b, c * d)
        ParenthesizedExpression, // Represents expressions enclosed in parentheses
        AssignmentExpression, // Represents assignment operations (e.g., a = b)
    }
}
