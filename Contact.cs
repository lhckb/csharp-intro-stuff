
namespace FirstTest
{
    internal class Contact
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int id { get; set; }

        public Contact(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        
        public void PrintFullContact()
        {
            Console.WriteLine($"Contact id: {this.id}");
            Console.WriteLine(this.Name);
            Console.WriteLine(this.Phone);
        }
    }
}
