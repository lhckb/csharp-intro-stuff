using Microsoft.EntityFrameworkCore;

namespace WebAPITest
{
    public class ContactEndpointRouter
    {
        public static void Map(WebApplication app)
        {
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

            app.MapDelete("/contacts/{id}", async (int id, ContactDb db) =>
            {
                Contact? contactToDel = await db.Contacts.FindAsync(1);
                if (!(contactToDel == null))
                {
                    db.Contacts.Remove(contactToDel);
                }
                
                await db.SaveChangesAsync();

                return Results.Ok($"Contact ID = {contactToDel.Id} deleted");
            });
        }
    }
}
