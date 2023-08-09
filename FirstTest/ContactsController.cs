using FirstTest.Exceptions;

namespace FirstTest
{
    internal class ContactsController
    {
        private ContactsRepository _contactsRepository = new ContactsRepository();

        public void PrintContacts()
        {
            List<Contact> allContacts = _contactsRepository.GetContacts();

            if (allContacts.Count() == 0)
            {
                Console.WriteLine("You have no contacts.");
            }

            foreach (Contact contact in allContacts)
            {
                contact.PrintFullContact();
                Console.WriteLine();
            }
        }

        public void AddContact(string name, string phone)
        {
            if (name.IsEmptyString() || phone.IsEmptyString())
            {
                throw new EmptyArgumentException();
            }

            Contact newContact = new Contact(name, phone);
            _contactsRepository.AddContact(newContact);
        }

        public void RemoveContact(string name) 
        {
            if (name.IsEmptyString()) 
            { 
                throw new EmptyArgumentException();
            }

            bool result = _contactsRepository.DeleteContact(name);

            if (!result) 
            { 
                throw new ContactNotFoundException();
            }
        }
    }
}
