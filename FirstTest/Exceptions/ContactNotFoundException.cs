
namespace FirstTest.Exceptions
{
    internal class ContactNotFoundException : ApplicationException
    {
        public ContactNotFoundException() : base("Contact not found")
        {
            
        }
    }
}
