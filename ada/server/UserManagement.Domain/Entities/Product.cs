namespace UserManagement.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Stock { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }


        // relationshipt
        public List<UserProductDetail> UserProductDetails { get; set; }
    }
}
