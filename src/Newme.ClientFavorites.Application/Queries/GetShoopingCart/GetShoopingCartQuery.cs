using MediatR;
using Newme.ClientFavorites.Application.ViewModels.ShoopingCart;

namespace Newme.ClientFavorites.Application.Commands.GetShoopingCart
{
    public class GetShoopingCartQuery : IRequest<ReadShoppingCartViewModel>
    {
        public GetShoopingCartQuery(Guid clientId)
        {
            ClientId = clientId;
        }

        public Guid ClientId { get; set; }
    }
}
