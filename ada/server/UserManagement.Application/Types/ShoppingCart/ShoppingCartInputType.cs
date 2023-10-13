namespace UserManagement.Application.Types.ShoppingCart
{
    public record ShoppingCartInputType
    {
        public Guid UserId { get; set; }

        public Guid ProductId { get; set; }

        public int QuantitySold { get; set; }
    }
}
