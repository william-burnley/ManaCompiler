namespace Mana.Core.CodeAnalysis.Syntax
{
    internal static class SyntaxFacts
    {
        public static int GetUnaryOperatorPrecedence(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.Plus:
                case SyntaxKind.Minus:
                case SyntaxKind.Negation:
                    return 6;

                default:
                    return 0;
            }
        }

        public static int GetBinaryOperatorPrecedence(this SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.Multiply:
                case SyntaxKind.Divide:
                    return 5;

                case SyntaxKind.Plus:
                case SyntaxKind.Minus:
                    return 4;

                case SyntaxKind.Equality:
                case SyntaxKind.Inequality:
                    return 3;

                case SyntaxKind.Conjunction:
                    return 2;

                case SyntaxKind.Disjunction:
                    return 1;

                default:
                    return 0;
            }
        }

        public static SyntaxKind GetKeywordKind(string text)
        {
            switch (text)
            {
                case "true":
                    return SyntaxKind.TrueKeyword;
                case "false":
                    return SyntaxKind.FalseKeyword;
                default:
                    return SyntaxKind.Identifier;
            }
        }
    }
}
