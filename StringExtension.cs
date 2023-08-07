
namespace FirstTest
{
    static class StringExtension
    {
        public static bool IsEmptyString(this string str)
        {
            if (str == null || str == "\n") { return true; }
            return false;
        }
    }
}
