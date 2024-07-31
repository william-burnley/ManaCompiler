namespace Mana.Core.CodeAnalysis.Syntax
{
    public sealed class AssignmentExpressionSyntax : ExpressionSyntax
    {
        public override SyntaxKind Kind => SyntaxKind.AssignmentExpression;
        public SyntaxToken IdentifierToken { get; }
        public SyntaxToken AssignmentToken { get; }
        public ExpressionSyntax Expression { get; }

        public AssignmentExpressionSyntax(SyntaxToken identiferToken, SyntaxToken assignmentToken, ExpressionSyntax expression)
        {
            IdentifierToken = identiferToken;
            AssignmentToken = assignmentToken;
            Expression = expression;
        }

        public override IEnumerable<SyntaxNode> GetChildren()
        {
            yield return IdentifierToken;
            yield return AssignmentToken;
            yield return Expression;
        }
    }
}
