namespace Newme.ClientFavorites.Application.InputModels.ShoopingCart
{
    public class ReadShoopingCartProductItemInputModel
    {
        public Guid ProductId { get; set; }
        public Guid ClientId { get; set; }
        public int Quantity { get; set;}
        public double UnitPrice { get; set; }
    }
}