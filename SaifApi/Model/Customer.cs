namespace SaifApi.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class User
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Skills { get; set; }
        public int Age { get; set; }
    }
}
