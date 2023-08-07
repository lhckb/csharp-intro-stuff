﻿
namespace FirstTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContactsController controller = new ContactsController();
            bool running = true;

            while (running)
            {
                Console.WriteLine("1- Add contact");
                Console.WriteLine("2- Read all contacts");
                Console.WriteLine("3- Delete contact");
                Console.WriteLine("4- Exit");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Console.WriteLine("Input contact name:");
                        string? name = Console.ReadLine();
                        Console.WriteLine("Input contact phone:");
                        string? phone = Console.ReadLine();

                        controller.AddContact(name, phone);
                        Console.WriteLine("Contact successfully added");

                        break;

                    case "2":
                        controller.PrintContacts();

                        break;
                
                    case "3":
                        Console.WriteLine("Input contact name to delete:");
                        string? nameToDelete = Console.ReadLine();
                        controller.RemoveContact(nameToDelete);

                        break;

                    case "4":
                        running = false;

                        break;

                }
            }
        }
    }
}
