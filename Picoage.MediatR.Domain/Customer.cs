namespace Picoage.MediatR.Domain
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; } = "TestUser";

        public string Password { get; set; } = "TestPaswword";

        public string Token { get; set; } = "TestToken"; 
    }
}
