using AutoMapper;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;
using Newme.ClientFavorites.Application.InputModels.Wishlist;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;
using Newme.ClientFavorites.Domain.Entities.Wishlist;

namespace Newme.ClientFavorites.Application.AutoMapper
{
    public class InputModelToDomainMappingProfile : Profile
    {
        public InputModelToDomainMappingProfile()
        {
            CreateMap<ReadShoopingCartProductItemInputModel, ShoopingCartProduct>()
                .ConstructUsing(x => new ShoopingCartProduct(
                    x.ProductId,
                    x.ClientId,
                    x.Quantity,
                    x.UnitPrice
                ));

            CreateMap<ReadWishlistProductItemInputModel, WishlistProduct>()
                .ConstructUsing(x => new WishlistProduct(
                    Guid.NewGuid(),
                    x.ProductId,
                    x.Name,
                    x.UnitPrice,
                    x.IsEmptyStock
                ));
        }
    }
}