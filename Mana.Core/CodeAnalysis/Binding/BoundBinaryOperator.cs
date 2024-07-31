using Mana.Core.CodeAnalysis.Syntax;

namespace Mana.Core.CodeAnalysis.Binding
{
    internal sealed class BoundBinaryOperator
    {
        public SyntaxKind SyntaxKind { get; }
        public BoundBinaryOperatorKind Kind { get; }
        public Type LeftType { get; }
        public Type RightType { get; }
        public Type Type { get; }

        private static BoundBinaryOperator[] _operators =
        {
            new BoundBinaryOperator(SyntaxKind.Plus, BoundBinaryOperatorKind.Addition, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.Minus, BoundBinaryOperatorKind.Subtraction, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.Multiply, BoundBinaryOperatorKind.Multiplication, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.Divide, BoundBinaryOperatorKind.Division, typeof(int)),
            new BoundBinaryOperator(SyntaxKind.Equality, BoundBinaryOperatorKind.Equality, typeof(int), typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.Inequality, BoundBinaryOperatorKind.Inequality, typeof(int), typeof(bool)),

            new BoundBinaryOperator(SyntaxKind.Conjunction, BoundBinaryOperatorKind.Conjunction, typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.Disjunction, BoundBinaryOperatorKind.Disjunction, typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.Equality, BoundBinaryOperatorKind.Equality, typeof(bool)),
            new BoundBinaryOperator(SyntaxKind.Inequality, BoundBinaryOperatorKind.Inequality, typeof(bool)),
        };

        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type type)
            : this(syntaxKind, kind, type, type, type)
        {
        }

        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type operandType, Type resultType)
            : this(syntaxKind, kind, operandType, operandType, resultType)
        {
        }

        private BoundBinaryOperator(SyntaxKind syntaxKind, BoundBinaryOperatorKind kind, Type leftType, Type rightType, Type resultType)
        {
            SyntaxKind = syntaxKind;
            Kind = kind;
            LeftType = leftType;
            RightType = rightType;
            Type = resultType;
        }

        public static BoundBinaryOperator? Bind(SyntaxKind syntaxKind, Type leftType, Type rightType)
        {
            foreach (var op in _operators)
            {
                if (op.SyntaxKind == syntaxKind && op.LeftType == leftType && op.RightType == rightType)
                    return op;
            }

            return null;
        }
    }
}
