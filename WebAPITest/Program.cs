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

            ContactEndpointRouter.Map(app);

            app.Run();
        }
    }
}