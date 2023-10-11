namespace UserManagement.Api.GraphQL.Types
{
    public record UserInputType
    {
        public string Account { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}
