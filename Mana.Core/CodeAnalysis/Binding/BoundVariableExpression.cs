using Mana.Core.CodeAnalysis.Symbols;

namespace Mana.Core.CodeAnalysis.Binding
{
    internal sealed class BoundVariableExpression : BoundExpression
    {
        public override BoundNodeKind Kind => BoundNodeKind.VariableExpression;
        public override Type Type => Variable.Type;
        public VariableSymbol Variable { get; }

        public BoundVariableExpression(VariableSymbol variable)
        {
            Variable = variable;
        }
    }
}
