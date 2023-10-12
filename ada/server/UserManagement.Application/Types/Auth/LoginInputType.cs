namespace UserManagement.Application.Types.Auth
{
    public record LoginInputType
    {
        public string IdentificationNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}
