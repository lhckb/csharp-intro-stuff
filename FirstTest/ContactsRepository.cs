
namespace FirstTest
{
    internal class ContactsRepository
    {
        private List<Contact> _contacts = new List<Contact>();
        private int _count = 0;

        public void AddContact(Contact newContact)
        {
            newContact.id = _count++;
            _contacts.Add(newContact);
        }

        public List<Contact> GetContacts()
        {
            return _contacts;
        }

        public bool DeleteContact(string name)
        { 
            foreach (Contact contact in _contacts)
            {
                if (contact.Name == name)
                {
                    _contacts.Remove(contact);
                    return true;
                }
            }

            return false;
        }
    }
}
