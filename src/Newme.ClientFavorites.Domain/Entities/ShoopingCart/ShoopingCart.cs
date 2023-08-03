namespace Newme.ClientFavorites.Domain.Entities.ShoopingCart
{
    public class ShoopingCart : Entity
    {
        public ShoopingCart(
            Guid id,
            Guid clientId, 
            Guid? couponId,
            double totalPrice,
            IList<ShoopingCartProduct> products) : base(id)
        { 
            _products = products;
            ClientId = clientId;
            CouponId = couponId;
            TotalPrice = totalPrice;
        }

        private IList<ShoopingCartProduct> _products;
        public IReadOnlyCollection<ShoopingCartProduct> Products => _products.ToList();
        public Guid ClientId { get; private set; }
        public Guid? CouponId { get; private set; }
        public double TotalPrice { get; private set; }

        public void ApplyDiscountCoupon(DiscountCoupon coupon)
        {
            CouponId = coupon.Id;
            TotalPrice -= TotalPrice * coupon.Percentage;
        }
    }
}
