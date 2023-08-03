using MediatR;
using Newme.ClientFavorites.Application.ViewModels.Wishlist;

namespace Newme.ClientFavorites.Application.Commands.GetWishlist
{
    public class GetWishlistQuery : IRequest<ReadWishlistViewModel>
    {
        public GetWishlistQuery(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; set; }
    }
}
