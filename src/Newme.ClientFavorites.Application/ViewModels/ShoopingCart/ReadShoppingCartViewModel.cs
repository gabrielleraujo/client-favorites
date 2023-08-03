using Newtonsoft.Json;

namespace Newme.ClientFavorites.Application.ViewModels.ShoopingCart
{
    public class ReadShoppingCartViewModel : ReadClientFavoriteViewModel
    {
        public ReadShoppingCartViewModel(
            IEnumerable<ReadShoppingCartProductViewModel> products, 
            Guid? couponId, 
            double totalPrice)
        {
            Products = products;
            CouponId = couponId;
            TotalPrice = totalPrice;
        }

        [JsonProperty("products")]
        public IEnumerable<ReadShoppingCartProductViewModel> Products { get; private set; }

        [JsonProperty("coupon_id")]
        public Guid? CouponId { get; private set; }

        [JsonProperty("total_price")]
        public double TotalPrice { get; private set; }
    }
}