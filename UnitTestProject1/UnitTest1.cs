using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
namespace UnitTestProject1
{
    [TestClass]
    public class ParserTest
    {
        private SpeakParser Setup(string text)
        {
            String input = "input text to parse";
            ICharStream stream = CharStreams.fromString(input);
            ITokenSource lexer = new SQLiteLexer(stream);
            ITokenStream tokens = new CommonTokenStream(lexer);
            SQLiteParser parser = new SQLiteParser(tokens);
            parser.BuildParseTree = true;
            IParseTree tree = parser.StartRule;
            KeyPrinter printer = new KeyPrinter();
            ParseTreeWalker.Default.Walk(printer, tree);
            inputStream = new AntlrInputStream(text);
            SpeakLexer speakLexer = new SpeakLexer(inputStream);
            CommonTokenStream commonTokenStream = new CommonTokenStream(speakLexer);
            SpeakParser speakParser = new SpeakParser(commonTokenStream);

            return speakParser;
        }

        [TestMethod]
        public void TestChat()
        {
            SpeakParser parser = Setup("aa \n");

            SpeakParser.ChatContext context = parser.chat();
            BasicSpeakVisitor visitor = new BasicSpeakVisitor();
            visitor.Visit(context);

            Assert.AreEqual(2, visitor.Lines.Count);
        }

        [TestMethod]
        public void TestLine()
        {
            SpeakParser parser = Setup("hello \n");

            SpeakParser.LineContext context = parser.line();
            BasicSpeakVisitor visitor = new BasicSpeakVisitor();
            SpeakLine line = (SpeakLine)visitor.VisitLine(context);

            Assert.AreEqual("john", line.Person);
            Assert.AreEqual("hello", line.Text);
        }

        [TestMethod]
        public void TestWrongLine()
        {
            SpeakParser parser = Setup("hello \n");

            var context = parser.line();

            Assert.IsInstanceOfType(context, typeof(SpeakParser.LineContext));
            Assert.AreEqual("john", context.name().GetText());
            Assert.IsNull(context.SAYS());
            Assert.AreEqual("john\"hello\"\n", context.GetText());
        }
    }
}
