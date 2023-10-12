using UserManagement.Application.Enums;

namespace UserManagement.Api.GraphQL.Types.Users
{
    public record UserInputType
    {
        public string FullName { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string IdentificationNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public UserProfiles UserProfile { get; set; } = UserProfiles.SHOPPING;
    }
}
