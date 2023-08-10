using Microsoft.EntityFrameworkCore;
using WebAPITest.Exceptions;

namespace WebAPITest
{
    public class ContactDb : DbContext
    {
        public DbSet<Contact> Contacts => Set<Contact>();

        private readonly IConfiguration _configuration;

        public ContactDb(DbContextOptions<ContactDb> options) : base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;userid=developer;password=senhamysql;database=contact_manager", 
                builder => builder.MigrationsAssembly("WebAPITest")
            );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Email).IsRequired();
            });
        }

        public async Task<bool> AddNewContact(Contact newContact)
        {
            string name = newContact.Name;
            string email = newContact.Email;
            if (name.IsEmptyString() || email.IsEmptyString())
            {
                throw new EmptyFieldException();
            }

            Contacts.Add(newContact);
            await SaveChangesAsync();
            return true;
        }

        public async Task<Contact> GetContactById(int id)
        {
            Contact? contact = await Contacts.FindAsync(id);
            if (contact == null)
            {
                throw new ContactNotFoundException(id);
            }

            return contact;
        }

        public async Task<bool> DeleteContactById(int id)
        {
            try
            {
                Contact contact = await GetContactById(id);
                Contacts.Remove(contact);
                return true;
            }
            catch(ContactNotFoundException ex)
            {
                throw ex;
            }
        }
    }
}
