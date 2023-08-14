
namespace WebAPITest
{
    static class StringExtension
    {
        public static bool IsEmptyString(this string str)
        {
            str = str.Trim();
            
            if (str.Equals("")) { return true; }
            return false;
        }
    }
}
