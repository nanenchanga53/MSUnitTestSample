using System;

namespace ClassLibraryProjects
{
    //string에 대한 클래스 라이브러리
    public static class StringLibrary
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
