using UserManagement.Application.Enums;

namespace UserManagement.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }

        public string IdentificationNumber { get; set; }

        public string Password { get; set; }

        public UserProfiles UserProfile { get; set; }

        // relationshipt
        public List<UserProductDetail> UserProductDetails { get; set; }
    }
}
