using AutoMapper;
using Newme.ClientFavorites.Application.ViewModels.ShoopingCart;
using Newme.ClientFavorites.Application.ViewModels.Wishlist;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;
using Newme.ClientFavorites.Domain.Entities.Wishlist;

namespace Newme.ClientFavorites.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        // Realizar mappers sem o automapper pq tem records.
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ShoopingCartProduct, ReadShoppingCartProductViewModel>();
            CreateMap<Wishlist, ReadWishlistViewModel>();
        }
    }
}
