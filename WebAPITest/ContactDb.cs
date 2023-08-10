using Microsoft.EntityFrameworkCore;

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
    }
}
