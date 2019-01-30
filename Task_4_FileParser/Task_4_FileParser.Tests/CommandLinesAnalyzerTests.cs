using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task_4_FileParser.Presentation;

namespace Task_4_FileParser.Tests
{
    [TestFixture]
    class CommandLinesAnalyzerTests
    {
        [TestCase(new string[] { "test.txt", "word", "-i" }, Feature.Find,
            "test.txt", "word", "", true)]
        [TestCase(new string[] { "C:\\test.txt", "word", "-n" }, Feature.Find,
            "C:\\test.txt", "word", "", false)]
        [TestCase(new string[] { "C:\\test.txt", "word", "anotherWord", "-n" },
            Feature.Replace, "C:\\test.txt", "word", "anotherWord", false)]
        [TestCase(new string[] { "C:\\qqq\\test.txt", "word", "anotherWord", "-i" },
            Feature.Replace, "C:\\qqq\\test.txt", "word", "anotherWord", true)]

        public void ParseArgs_ValidArguments_ReturnValidResult(string[] args,
            Feature expectedFeature, string expectedPath,
            string expectedPattern, string expectedNewValue,
            bool expectedIgnoreCase)
        {
            string resultPath;
            string resultPattern;
            string resultNewValue;
            bool resultIgnoreCase;
            Feature resultFeature = CommandLinesAnalyzer.ParseArgs(args,
                out resultPath, out resultPattern, out resultNewValue,
                out resultIgnoreCase);

            Assert.AreEqual(expectedFeature, resultFeature);
            Assert.AreEqual(expectedPath, resultPath);
            Assert.AreEqual(expectedPattern, resultPattern);
            Assert.AreEqual(expectedNewValue, resultNewValue);
            Assert.AreEqual(expectedIgnoreCase, resultIgnoreCase);
        }

        [Test]
        public void ParseArgs_InvalidKeyArgument_ReturnsException()
        {
            string[] args = { "C:\\test.txt", "word", "anotherWord", "-d" };
            string resultPath;
            string resultPattern;
            string resultNewValue;
            bool resultIgnoreCase;

            Assert.Catch<ArgumentException>(() => CommandLinesAnalyzer.ParseArgs(
                args, out resultPath, out resultPattern, out resultNewValue,
                out resultIgnoreCase));
        }
        [Test]
        public void ParseArgs_LackOfArguments_ReturnsException()
        {
            string[] args = { "C:\\test.txt", "word" };
            string resultPath;
            string resultPattern;
            string resultNewValue;
            bool resultIgnoreCase;

            Assert.Catch<ArgumentException>(() => CommandLinesAnalyzer.ParseArgs(
                args, out resultPath, out resultPattern, out resultNewValue,
                out resultIgnoreCase));
        }
        [Test]
        public void ParseArgs_ExtraArguments_ReturnsException()
        {
            string[] args = { "C:\\test.txt", "word", "anotherWord", "-d", "extraString" };
            string resultPath;
            string resultPattern;
            string resultNewValue;
            bool resultIgnoreCase;

            Assert.Catch<ArgumentException>(() => CommandLinesAnalyzer.ParseArgs(
                args, out resultPath, out resultPattern, out resultNewValue,
                out resultIgnoreCase));
        }
    }
}
