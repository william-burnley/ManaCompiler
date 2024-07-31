using Mana.Common;

namespace Mana.Core.CodeAnalysis.Diagnostics
{
    public sealed class Diagnostic
    {
        public TextSpan Span { get; }
        public string Message { get; }

        public Diagnostic(TextSpan span, string message)
        {
            Span = span;
            Message = message;
        }

        public override string ToString() => Message;
    }
}
