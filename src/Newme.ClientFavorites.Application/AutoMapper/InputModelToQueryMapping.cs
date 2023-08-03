using AutoMapper;
using Newme.ClientFavorites.Application.Commands.CalculateDiscountCoupon;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;

namespace Newme.ClientFavorites.Application.AutoMapper
{
    public class InputModelToQueryMapping : Profile
    {
        public InputModelToQueryMapping()
        {
            CreateMap<CalculateDiscountCouponInputModel, CalculateDiscountCouponQuery>()
                .ConstructUsing(x => new CalculateDiscountCouponQuery(
                    x.ClientId,
                    x.Coupon,
                    x.TotalPrice,
                    x.Products
                ));
        }
    }
}
