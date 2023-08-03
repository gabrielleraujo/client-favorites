namespace Newme.ClientFavorites.Application.InputModels.ShoopingCart
{
    public class InsertShoopingCartInputModel
    {
        public Guid ClientId { get; set; }
        public string? CouponName { get; set; }
        public double TotalPrice { get; set; }
        public IEnumerable<ReadShoopingCartProductItemInputModel> Products { get; set; }
    }
}
