using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.Data.SqlClient;

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
        public void TestInsertAndSelectData()
        {
            // Arrange
            using (var connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;Integrated Security=True"))
            {
                connection.Open();

                // Act: Insert sample data
                using (var command = new SqlCommand(
                    "INSERT INTO Employees (Id, FirstName, LastName, Salary) VALUES " +
                    "(4, 'Alice', 'Johnson', 80000.00);",
                    connection))
                {
                    command.ExecuteNonQuery();
                }

                // Act: Perform a SELECT query
                using (var command = new SqlCommand("SELECT * FROM Employees WHERE Id = 4;", connection))
                using (var reader = command.ExecuteReader())
                {
                    // Assert: Verify inserted data
                    Assert.IsTrue(reader.Read());
                    Assert.AreEqual("Alice", reader["FirstName"]);
                    Assert.AreEqual("Johnson", reader["LastName"]);
                    Assert.AreEqual(80000.00, reader["Salary"]);
                }

                connection.Close();
            }
        }

        [TestMethod]
        public void TestInvalidDatabaseConnection()
        {
            // Arrange & Act & Assert: Verify exception for invalid connection string
            Assert.ThrowsException<SqlException>(() =>
            {
                using (var connection = new SqlConnection("InvalidConnectionString"))
                {
                    connection.Open();
                }
            });
        }
    }
}
