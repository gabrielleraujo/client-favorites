namespace Newme.ClientFavorites.Application.InputModels.ShoopingCart
{
    public class CalculateDiscountCouponInputModel
    {
        public Guid ClientId { get; set; }
        public string Coupon { get; set; }
        public double TotalPrice { get; set; }
        public IEnumerable<ReadShoopingCartProductItemInputModel> Products { get; set; }
    }
}