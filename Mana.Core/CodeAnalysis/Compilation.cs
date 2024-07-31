using Mana.Core.CodeAnalysis.Symbols;
using Mana.Core.CodeAnalysis.Syntax;
using Mana.Core.CodeAnalysis.Binding;
using Mana.Core.CodeAnalysis.Diagnostics;
using Mana.Core.CodeAnalysis.Evaluation;

namespace Mana.Core.CodeAnalysis
{
    public sealed class Compilation
    {
        public SyntaxTree Syntax { get; }

        public Compilation(SyntaxTree syntax)
        {
            Syntax = syntax;
        }

        public EvalutionResult Evaluate(Dictionary<VariableSymbol, object> variables)
        {
            var binder = new Binder(variables);
            var boundExpression = binder.BindExpression(Syntax.Root);

            var diagnostics = Syntax.Diagnostics.Concat(binder.Diagnostics).ToArray();

            if (diagnostics.Any())
                return new EvalutionResult(diagnostics, null);

            var evaluator = new Evaluator(boundExpression, variables);
            var value = evaluator.Evaluate();

            return new EvalutionResult(Array.Empty<Diagnostic>(), value);
        }
    }
}
