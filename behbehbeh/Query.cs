using Antlr4.Runtime.Atn;
using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace behbehbeh
{
    public class ParserResult
    {
        public bool IsValid { get; internal set; }
        public int ErrorPosition { get; internal set; } = -1;
        public string ErrorMessage { get; internal set; }
        public string Result { get; internal set; }
    }

    public static class Query
    {
        public static ParserResult Parse(string expression, bool secondRun = false)
        {
            if (String.IsNullOrWhiteSpace(expression))
            {
                return new ParserResult
                {
                    IsValid = true,
                    Result = null
                };
            }

            var inputStream = new AntlrInputStream(expression);
            var lexer = new QueryLanguageLexer(inputStream);
            var tokenStream = new CommonTokenStream(lexer);
            var parser = new QueryLanguageParser(tokenStream);

            lexer.RemoveErrorListeners();
            parser.RemoveErrorListeners();
            var customErrorListener = new QueryLanguageErrorListener();
            parser.AddErrorListener(customErrorListener);
            var visitor = new QueryLanguageVisitor();

            var queryExpression = parser.query();
            var result = visitor.Visit(queryExpression);
            var isValid = customErrorListener.IsValid;
            var errorLocation = customErrorListener.ErrorLocation;
            var errorMessage = customErrorListener.ErrorMessage;
            if (result != null)
            {
                isValid = false;
            }

            if (!isValid && !secondRun)
            {
                var cleanedFormula = string.Empty;
                var tokenList = tokenStream.GetTokens().ToList();
                for (var i = 0; i < tokenList.Count - 1; i++)
                {
                    cleanedFormula += tokenList[i].Text;
                }
                var originalErrorLocation = errorLocation;
                var retriedResult = Parse(cleanedFormula, true);
                if (!retriedResult.IsValid)
                {
                    retriedResult.ErrorPosition = originalErrorLocation;
                    retriedResult.ErrorMessage = errorMessage;
                }
                return retriedResult;
            }
            return new ParserResult
            {
                IsValid = isValid,
                Result = isValid || result != null
                ? result
                : null,
                ErrorPosition = errorLocation,
                ErrorMessage = isValid ? null : errorMessage
            };
        }
    }

    public class QueryLanguageErrorListener : BaseErrorListener
    {
        public bool IsValid { get; private set; } = true;
        public int ErrorLocation { get; private set; } = -1;
        public string ErrorMessage { get; private set; }

        public override void ReportAmbiguity(
          Parser recognizer, DFA dfa,
          int startIndex, int stopIndex,
          bool exact, BitSet ambigAlts,
          ATNConfigSet configs)
        {
            IsValid = false;
        }

        public override void ReportAttemptingFullContext(
          Parser recognizer, DFA dfa,
          int startIndex, int stopIndex,
          BitSet conflictingAlts, SimulatorState conflictState)
        {
            IsValid = false;
        }

        public override void ReportContextSensitivity(
          Parser recognizer, DFA dfa,
          int startIndex, int stopIndex,
          int prediction, SimulatorState acceptState)
        {
            IsValid = false;
        }

        public override void SyntaxError(
          IRecognizer recognizer, IToken offendingSymbol,
          int line, int charPositionInLine,
         string msg, RecognitionException e)
        {
            IsValid = false;
            ErrorLocation = ErrorLocation == -1 ? charPositionInLine : ErrorLocation;
            ErrorMessage = msg;
        }
    }
}
