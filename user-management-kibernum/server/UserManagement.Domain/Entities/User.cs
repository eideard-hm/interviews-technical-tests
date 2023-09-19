namespace UserManagement.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Account { get; set; }

        public string Password { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }
    }
}
