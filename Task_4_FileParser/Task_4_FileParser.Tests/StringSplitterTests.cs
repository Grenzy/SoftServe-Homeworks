using System;
using NUnit.Framework;
using Task_4_FileParser.BL;

namespace Task_4_FileParser.Tests
{
    [TestFixture]
    class StringSplitterTests
    {

        [TestCase("", new int[] { }, 2, new string[] { })]
        [TestCase("babebaerana", new int[] { 8 }, 3, 
            new string[] { "babebaer", "ana", })]
        [TestCase("anababanaanaebaer", new int[] { 0, 6, 9 }, 3,
            new string[] { "", "ana", "bab", "ana", "", "ana", "ebaer", })]
        [TestCase("anaana", new int[] { 0, 3 }, 3,
            new string[] { "", "ana", "", "ana" })]
        [TestCase("anababebaer", new int[] { 3, 7 }, 2,
            new string[] { "ana", "ba", "be", "ba", "er" })]
        public void SplitByIndexes_ValidParams_ReturnValidResult(string source,
            int[] indexes, int length, string[] expected)
        {
            StringSplitter stringSplitter = CreateSplitter();

            string[] result =
                stringSplitter.SplitByIndexes(source, indexes, length);

            CollectionAssert.AreEqual(result, expected);
        }

        [TestCase(null, new int[] { }, 0)]
        [TestCase("abba", null, 0)]
        public void SplitByIndexes_NullArgument_ReturnsException(string source,
            int[] indexes, int length)
        {
            StringSplitter stringSplitter = CreateSplitter();
            Assert.Catch<ArgumentNullException>(
                () => stringSplitter.SplitByIndexes(source, indexes, length));
        }

        private StringSplitter CreateSplitter()
        {
            return new StringSplitter();
        }
    }

}
