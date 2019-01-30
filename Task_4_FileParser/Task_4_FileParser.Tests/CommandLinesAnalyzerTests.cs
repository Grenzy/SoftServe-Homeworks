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

    }
}
