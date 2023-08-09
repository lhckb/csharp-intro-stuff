
namespace FirstTest.Exceptions
{
    internal class EmptyArgumentException: Exception
    {
        public EmptyArgumentException() : base("String passed as argument is empty")
        { 
        }
    }
}
