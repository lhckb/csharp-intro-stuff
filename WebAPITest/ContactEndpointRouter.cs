using Microsoft.EntityFrameworkCore;

namespace WebAPITest
{
    public class ContactEndpointRouter
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/contacts", async (ContactDb db) =>
            {
                return await ContactController.GetAllContactsAsync(db);
            });

            app.MapGet("/contacts/{id}", async (int id, ContactDb db) =>
            {
                return await ContactController.GetContactByIdAsync(id, db);
            });

            app.MapPost("/contacts", async (Contact newContact, ContactDb db) =>
            {
                return await ContactController.CreateContactAsync(newContact, db);
            });

            app.MapDelete("/contacts/{id}", async (int id, ContactDb db) =>
            {
                return await ContactController.DeleteContactAsync(id, db);
            });

            app.MapPut("/contacts/{id}", async (int id, Contact updatedContact, ContactDb db) =>
            {
                return await ContactController.UpdateContactAsync(id, updatedContact, db);
            });
        }
    }
}
