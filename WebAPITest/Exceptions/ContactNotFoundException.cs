namespace WebAPITest.Exceptions
{
    public class ContactNotFoundException : ApplicationException
    {
        public ContactNotFoundException(int id) : base($"Contact with ID {id} not found")
        {
        }
    }
}
