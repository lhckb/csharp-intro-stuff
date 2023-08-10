﻿using Microsoft.EntityFrameworkCore;
using WebAPITest.Exceptions;

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
            try
            {
                Contact contact = await db.GetContactById(id);
                return Results.Ok(new { Result = contact });
            }
            catch (ContactNotFoundException ex)
            {
                return Results.UnprocessableEntity(new { Message = ex.Message });
            }
        }

        public static async Task<IResult> CreateContactAsync(Contact newContact, ContactDb db)
        {
            try
            {
                _ = await db.AddNewContact(newContact);
                return Results.Ok(new { Result = "Created Successfully" });
            }
            catch (EmptyFieldException ex)
            {
                return Results.BadRequest(new { Message = ex.Message });
            }
        }

        public static async Task<IResult> DeleteContactAsync(int id, ContactDb db)
        {
            try
            {
                _ = await db.DeleteContactById(id);
                return Results.Ok(new { Result = "Deleted successfully" });
            }
            catch (ContactNotFoundException ex)
            {
                return Results.UnprocessableEntity(new { Message = ex.Message });
            }
        }
    }
}
