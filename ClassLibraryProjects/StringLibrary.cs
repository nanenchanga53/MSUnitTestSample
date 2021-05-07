using System;

namespace ClassLibraryProjects
{
    public static class StringLibrary
    {
        public static bool StartsWithUpper(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return false;

            char ch = str[0];
            return char.IsUpper(ch);
        }

        public static int StringLength(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            return str.Length;

        }
    }
}
