using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringLibraries;
using System;


//참고 사이트
//https://qiita.com/mima_ita/items/55394bcc851eb8b6dc24
//https://www.meziantou.net/mstest-v2-data-tests.htm

namespace UnitTestProject
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStartsWithUpper()
        {
            // Tests that we expect to return true.
            string[] words = { "Alphabet", "Zebra", "ABC", "Αθήνα", "Москва" };
            foreach (var word in words)
            {
                bool result = word.StartsWithUpper();
                Assert.IsTrue(result,
                       String.Format("Expected for '{0}': true; Actual: {1}",
                                     word, result));
            }
        }

        [TestMethod]
        public void TestDoesNotStartWithUpper()
        {
            // Tests that we expect to return false.
            string[] words = { "alphabet", "error", "zebra", "abc", "αυτοκινητοβιομηχανία", "государство",
                   "1234", ".", ";", " " };
            foreach (var word in words)
            {
                bool result = word.StartsWithUpper();
                Assert.IsFalse(result,
                       String.Format("Expected for '{0}': false; Actual: {1}",
                                     word, result));
            }
        }
        [TestMethod]
        public void DirectCallWithNullOrEmpty()
        {
            // Tests that we expect to return false.
            string[] words = { string.Empty, null };
            foreach (var word in words)
            {
                bool result = StringLibrarie.StartsWithUpper(word);
                Assert.IsFalse(result,
                       String.Format("Expected for '{0}': false; Actual: {1}",
                                     word == null ? "<null>" : word, result));
            }
        }

        [DataTestMethod]
        [DataRow("asdf")]
        [DataRow("as")]
        [DataRow("abc")]
        [DataRow("abcde")] //이 케이스 때문에 실패
        public void IsShortString(string value)
        {
            var stringLength = value.StringLength();
            bool result = true;

            if (stringLength == 0)
            {
                result = false;
            }

            else if (stringLength < 5)
            {
                result = true;
            }
            else if (stringLength >= 5)
            {
                result = false;
            }

            Assert.IsTrue(result, $"{value} should not be prime");
        }

    }
}
