namespace UserManagement.Domain.Entities
{
    public class UserProductDetail
    {
        public Guid ProductId { get; set; }

        public Guid UserId  { get; set; }

        public decimal UnitPrice { get; set; }

        public int QuantitySold { get; set; }

        public decimal Total { get; set; }

        // relationshipt
        public Product Product { get; set; }

        public User User { get; set; }
    }
}
