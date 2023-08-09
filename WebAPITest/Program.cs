using Microsoft.EntityFrameworkCore;

namespace WebAPITest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ContactDb>(opt => opt.UseInMemoryDatabase("Contacts"));
           
            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.MapGet("/contacts", async (ContactDb db) =>
            {
                return await db.Contacts.ToListAsync();
            });

            app.MapPost("/contacts", async (Contact newContact, ContactDb db) =>
            {
                db.Contacts.Add(newContact);
                await db.SaveChangesAsync();

                return Results.Created($"/contacts/{newContact.Id}", newContact);
            });

            app.Run();
        }
    }
}