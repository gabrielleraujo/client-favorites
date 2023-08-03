using MediatR;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;
using Newme.ClientFavorites.Application.ViewModels.ShoopingCart;
using OneOf;

namespace Newme.ClientFavorites.Application.Commands.CalculateDiscountCoupon
{
    public class CalculateDiscountCouponQuery : IRequest<OneOf<ReadShoppingCartViewModel, string>>
    {
        public CalculateDiscountCouponQuery(
            Guid clientId,
            string coupon,
            double totalPrice,
            IEnumerable<ReadShoopingCartProductItemInputModel> products)
        {
            ClientId = clientId;
            Coupon = coupon;
            TotalPrice = totalPrice;
            Products = products;
        }

        public Guid ClientId { get; private set; }
        public string Coupon { get; private set; }
        public double TotalPrice { get; private set; }
        public IEnumerable<ReadShoopingCartProductItemInputModel> Products { get; private set; }
    }
}
