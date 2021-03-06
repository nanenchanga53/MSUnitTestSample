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

            //이곳에서 직접 소스를 고쳐보면서 LiveTest가 잘 작동하는지 확인해 보자
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
