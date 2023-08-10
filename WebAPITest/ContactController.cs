using Microsoft.EntityFrameworkCore;

namespace WebAPITest
{
    public class ContactController
    {
        public static async Task<IResult> GetAllContactsAsync(ContactDb db)
        {
            List<Contact> result = await db.Contacts.ToListAsync();
            return Results.Ok(new { Result = result });
        }

        public static async Task<IResult> GetContactByIdAsync(int id, ContactDb db)
        {
            Contact? contact = await db.Contacts.FindAsync(id);
            if (!(contact == null))
            {
                return Results.Ok(new { Result = contact });
            }

            return Results.UnprocessableEntity(new { Message = $"Contact with ID {id} not found" });
        }

        public static async Task<IResult> CreateContactAsync(Contact newContact, ContactDb db)
        {
            db.Contacts.Add(newContact);
            await db.SaveChangesAsync();

            return Results.Ok(new { Result = "Created Successfully" });
        }

        public static async Task<IResult> DeleteContactAsync(int id, ContactDb db)
        {
            Contact? contactToDel = await db.Contacts.FindAsync(id);
            if (!(contactToDel == null))
            {
                db.Contacts.Remove(contactToDel);
                await db.SaveChangesAsync();
                return Results.Ok(new { Result = "Deleted Successfully" });
            }

            return Results.UnprocessableEntity(new { Message = $"Contact with ID {id} not found" });
        }
    }
}
