using Mana.Core.CodeAnalysis.Diagnostics;

namespace Mana.Core.CodeAnalysis.Evaluation
{
    public sealed class EvalutionResult
    {
        public IReadOnlyList<Diagnostic> Diagnostics { get; }
        public object? Value { get; }

        public EvalutionResult(IEnumerable<Diagnostic> diagnostics, object? value)
        {
            Diagnostics = diagnostics.ToArray();
            Value = value;
        }
    }

}
