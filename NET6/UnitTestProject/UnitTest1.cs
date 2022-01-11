using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StringLibraries;
using System;
using System.Collections.Generic;
using System.IO;

//참고 사이트
//https://qiita.com/mima_ita/items/55394bcc851eb8b6dc24
//https://www.meziantou.net/mstest-v2-data-tests.htm

namespace UnitTestProject
{

    [TestClass]
    public class UnitTest1
    {

        /// <summary>
        /// 배열에 값을 넣어놓고 확인하는 케이스
        /// </summary>
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

        /// <summary>
        /// 배열에 단어를 넣은 후 확인하는 케이스
        /// </summary>
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

        /// <summary>
        /// null 값 확인이 반영되는지 확인 케이스
        /// </summary>
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


        /// <summary>
        /// 여러 케이스 설정
        /// </summary>
        /// <param name="value">DataRow값</param>
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


        /// <summary>
        /// 시간제한 설정
        /// </summary>
        [TestMethod]
        [Timeout(2000)]  // Milliseconds
        public void TestTimeout()
        {
            // 실패
            System.Threading.Thread.Sleep(10000);

            ////성공
            //System.Threading.Thread.Sleep(1000);
        }

        #region Json파일 사용
        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void TestJson(string testData)
        {
            bool result = testData.StartsWithUpper();
            Assert.IsTrue(result);
        }

        public static IEnumerable<object[]> GetData()
        {
            using (StreamReader file = File.OpenText(@"test.json"))
            {
                using (JsonTextReader reader = new JsonTextReader(file))
                {
                    JObject o1 = (JObject)JToken.ReadFrom(reader);
                    foreach (var jsonData in o1["Test"])
                    {
                        string testData = jsonData["data"].ToString();
                        yield return new object[] { testData };

                    }
                }
            }

            //yield return new object[] { "a" };
            //yield return new object[] { "b" };
            //yield return new object[] { "c" };
        }
        #endregion



    }


}
