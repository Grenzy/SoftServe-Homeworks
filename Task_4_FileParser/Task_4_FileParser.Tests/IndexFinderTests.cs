using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Task_4_FileParser.BL;

namespace Task_4_FileParser.Tests
{
    [TestFixture]
    class IndexFinderTests
    {
        [TestCase("", "index", true, new int[] { })]
        [TestCase("inde a", "index", true, new int[] { })]
        [TestCase("aAba", "a", false, new int[] { 0, 3 })]
        [TestCase("index Index sdindex", "index", true, new int[] { 0, 6, 14 })]
        [TestCase("index Index sdindex", "index", false, new int[] { 0, 14 })]
  
        public void GetIndexes_ValidArguments_ReturnValidResult(
            string source, string pattern, bool IgnoreCase, int[] expected)
        {
            IndexFinder indexFinder = CreateFinder();

            int[] result = indexFinder.GetIndexes(source, pattern, IgnoreCase);

            CollectionAssert.AreEqual(expected, result);
        }

        [TestCase(null, "a", true)]
        [TestCase(null, "a", false)]
        [TestCase("abba", null, true)]
        public void GetIndexes_NullArgument_returnsException(string source, string pattern, bool IgnoreCase)
        {
            IndexFinder indexFinder = CreateFinder();

            Assert.Catch<ArgumentNullException>(() => indexFinder.GetIndexes(source, pattern, IgnoreCase));
        }

        public IndexFinder CreateFinder()
        {
            return new IndexFinder();
        }
    }
}