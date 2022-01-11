using System;

namespace StringLibrary
{
    public static class StringLibraryClass
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
            else if(str.Length > 1000)
            {
                return false;  //코드 검사시 실행되지 않는 위치로 표시되어야 한다.
            }
            char ch = str[0];
            return char.IsUpper(ch);
        }

        /// <summary>
        /// 글자수 세기
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int StringLength(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            return str.Length;

        }
    }
}
