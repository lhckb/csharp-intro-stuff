
namespace FirstTest
{
    static class StringExtension
    {
        public static bool IsEmptyString(this string str)
        {
            str = str.Trim();
            
            if (str.Equals(null) || str.Equals("")) { return true; }
            return false;
        }
    }
}
