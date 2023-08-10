namespace WebAPITest.Exceptions
{
    public class EmptyFieldException : ApplicationException
    {
        public EmptyFieldException() : base("Request data cannot contain empty fields")
        {          
        }
    }
}
