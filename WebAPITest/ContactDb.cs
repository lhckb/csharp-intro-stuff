using Microsoft.EntityFrameworkCore;

namespace WebAPITest
{
    public class ContactDb : DbContext
    {
        public ContactDb(DbContextOptions<ContactDb> options) : base(options) 
        {
            
        }

        public DbSet<Contact> Contacts => Set<Contact>();
    }
}
