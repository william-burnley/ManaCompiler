using System;
using Mana.Core.CodeAnalysis.Syntax;
using Xunit;

namespace Mana.Tests.CodeAnalysis.Syntax
{
    public class LexerTest
    {
        [Theory]
        [MemberData(nameof(GetTokensData))]
        public void LexerLexesToken(SyntaxKind kind, string text)
        {
            var tokens = SyntaxTree.ParseTokens(text);

            var token = Assert.Single(tokens);
            Assert.Equal(kind, token.Kind);
            Assert.Equal(text, token.Text);
        }

        [Theory]
        [MemberData(nameof(GetTokenPairsData))]
        public void LexerLexesTokenPairs(SyntaxKind t1Kind, string t1Text,
                                         SyntaxKind t2Kind, string t2Text)
        {
            var text = t1Text + t2Text;
            var tokens = SyntaxTree.ParseTokens(text).ToArray();

            Assert.Equal(2, tokens.Length);
            Assert.Equal(tokens[0].Kind, t1Kind);
            Assert.Equal(tokens[0].Text, t1Text);
            Assert.Equal(tokens[1].Kind, t2Kind);
            Assert.Equal(tokens[1].Text, t2Text);
        }

        [Theory]
        [MemberData(nameof(GetTokenPairsWithSeparatorData))]
        public void LexerLexesTokenPairsWithSeparators(SyntaxKind t1Kind, string t1Text,
                                                       SyntaxKind separatorKind, string separatorText,
                                                       SyntaxKind t2Kind, string t2Text)
        {
            var text = t1Text + separatorText + t2Text;
            var tokens = SyntaxTree.ParseTokens(text).ToArray();

            Assert.Equal(3, tokens.Length);
            Assert.Equal(tokens[0].Kind, t1Kind);
            Assert.Equal(tokens[0].Text, t1Text);
            Assert.Equal(tokens[1].Kind, separatorKind);
            Assert.Equal(tokens[1].Text, separatorText);
            Assert.Equal(tokens[2].Kind, t2Kind);
            Assert.Equal(tokens[2].Text, t2Text);
            
        }

        public static IEnumerable<object[]> GetTokensData()
        {
            foreach (var t in GetTokens().Concat(GetSeparators()))
                yield return new object[] { t.kind, t.text };
        }

        public static IEnumerable<object[]> GetTokenPairsData()
        {
            foreach (var t in GetTokenPairs())
                yield return new object[] { t.t1Kind, t.t1Text, t.t2Kind, t.t2Text };
        }

        public static IEnumerable<object[]> GetTokenPairsWithSeparatorData()
        {
            foreach (var t in GetTokenPairsWithSeparator())
                yield return new object[] { t.t1Kind, t.t1Text, t.separatorKind, t.separatorText, t.t2Kind, t.t2Text };
        }

        private static IEnumerable<(SyntaxKind kind, string text)> GetTokens()
        {
            return new[]
            {
                (SyntaxKind.Plus, "+"),
                (SyntaxKind.Minus, "-"),
                (SyntaxKind.Multiply, "*"),
                (SyntaxKind.Divide, "/"),
                (SyntaxKind.Negation, "!"),
                (SyntaxKind.Assignment, "="),
                (SyntaxKind.Conjunction, "&&"),
                (SyntaxKind.Disjunction, "||"),
                (SyntaxKind.Equality, "=="),
                (SyntaxKind.Inequality, "!="),
                (SyntaxKind.OpenParenthesis, "("),
                (SyntaxKind.CloseParenthesis, ")"),
                (SyntaxKind.FalseKeyword, "false"),
                (SyntaxKind.TrueKeyword, "true"),
                (SyntaxKind.Number, "1"),
                (SyntaxKind.Number, "123"),
                (SyntaxKind.Identifier, "a"),
                (SyntaxKind.Identifier, "abc"),
            };
        }

        private static IEnumerable<(SyntaxKind kind, string text)> GetSeparators()
        {
            return new[]
            {
                (SyntaxKind.WhiteSpace, " "),
                (SyntaxKind.WhiteSpace, "  "),
                (SyntaxKind.WhiteSpace, "\r"),
                (SyntaxKind.WhiteSpace, "\n"),
                (SyntaxKind.WhiteSpace, "\r\n"),
            };
        }



        private static bool RequiresSeparator(SyntaxKind t1Kind, SyntaxKind t2Kind)
        {
            var t1IsKeyword = t1Kind.ToString().EndsWith("Keyword");
            var t2IsKeyword = t2Kind.ToString().EndsWith("Keyword");

            if (t1Kind == SyntaxKind.Identifier && t2Kind == SyntaxKind.Identifier)
                return true;

            if (t1IsKeyword && t2IsKeyword)
                return true;

            if (t1IsKeyword && t2Kind == SyntaxKind.Identifier)
                return true;

            if (t1Kind == SyntaxKind.Identifier && (t2IsKeyword))
                return true;

            if (t1Kind == SyntaxKind.Number && t2Kind == SyntaxKind.Number)
                return true;

            if (t1Kind == SyntaxKind.Negation && t2Kind == SyntaxKind.Assignment)
                return true;

            if (t1Kind == SyntaxKind.Negation && t2Kind == SyntaxKind.Equality)
                return true;

            if (t1Kind == SyntaxKind.Assignment && t2Kind == SyntaxKind.Assignment)
                return true;

            if (t1Kind == SyntaxKind.Assignment && t2Kind == SyntaxKind.Equality)
                return true;


            return false;
        }

        private static IEnumerable<(SyntaxKind t1Kind, string t1Text, SyntaxKind t2Kind, string t2Text)> GetTokenPairs()
        {
            foreach (var t1 in GetTokens())
            {
                foreach (var t2 in GetTokens())
                {
                    if (RequiresSeparator(t1.kind, t2.kind) == false)
                        yield return (t1.kind, t1.text, t2.kind, t2.text);
                }
            }
        }

        private static IEnumerable<(SyntaxKind t1Kind, string t1Text,
                                    SyntaxKind separatorKind, string separatorText,
                                    SyntaxKind t2Kind, string t2Text)> GetTokenPairsWithSeparator()
        {
            foreach (var t1 in GetTokens())
            {
                foreach (var t2 in GetTokens())
                {
                    if (RequiresSeparator(t1.kind, t2.kind))
                    {
                        foreach (var s in GetSeparators())
                        yield return (t1.kind, t1.text, s.kind, s.text, t2.kind, t2.text);

                    }
                }
            }
        }
    }
}
