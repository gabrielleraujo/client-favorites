using AutoMapper;
using Newme.ClientFavorites.Application.Commands.AddWishlist;
using Newme.ClientFavorites.Application.Commands.DeleteWishlist;
using Newme.ClientFavorites.Application.Commands.InsertShoopingCart;
using Newme.ClientFavorites.Application.Commands.RegisterDiscountCoupon;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;
using Newme.ClientFavorites.Application.InputModels.Wishlist;

namespace Newme.ClientFavorites.Application.AutoMapper
{
    public class InputModelToCommandMappingProfile : Profile
    {
        public InputModelToCommandMappingProfile()
        { 
            CreateMap<InsertShoopingCartInputModel, InsertShoopingCartCommand>()
                .ConstructUsing(x => new InsertShoopingCartCommand(
                    x.ClientId,
                    x.CouponName,
                    x.TotalPrice,
                    x.Products
                ));

            CreateMap<AddWishlistInputModel, AddWishlistCommand>()
                .ConstructUsing(x => new AddWishlistCommand(
                    x.ClientId,
                    x.Product
                ));

            CreateMap<DeleteWishlistInputModel, DeleteWishlistCommand>()
                .ConstructUsing(x => new DeleteWishlistCommand(
                    x.ClientId,
                    x.ProductId
                ));

            CreateMap<DeleteWishlistInputModel, DeleteWishlistCommand>()
                .ConstructUsing(x => new DeleteWishlistCommand(
                    x.ClientId,
                    x.ProductId
                ));

            CreateMap<RegisterDiscountCouponInputModel, RegisterDiscountCouponCommand>()
                .ConstructUsing(x => new RegisterDiscountCouponCommand(
                    x.Name,
                    x.Percentage,
                    x.Description
                ));   
        }
    }
}