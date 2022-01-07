using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLibraries
{
    public static class StringLibrarie
    {
        /// <summary>
        /// 첫 글자가 대문자인지 확인
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StartsWithUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            char ch = str[0];

            //여기에 ch의 값을 변경하면서 Live Unit Testing이 제대로 실행되는지 확인하자
            //ch = str[1];

            return char.IsUpper(ch);
        }

        /// <summary>
        /// 글자수 세기
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int StringLength(this string str) => string.IsNullOrEmpty(str) ? 0 : str.Length;
        
    }
}
