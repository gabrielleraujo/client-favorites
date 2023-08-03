using AutoMapper;
using MediatR;
using Newme.ClientFavorites.Application.ViewModels.Wishlist;
using Newme.ClientFavorites.Domain.Repositories;

namespace Newme.ClientFavorites.Application.Commands.GetWishlist
{
    public class GetWishlistQueryHandler : IRequestHandler<GetWishlistQuery, ReadWishlistViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IWishlistRepository _repository;

        public GetWishlistQueryHandler(
            IMapper mapper,
            IWishlistRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public async Task<ReadWishlistViewModel> Handle(GetWishlistQuery query, CancellationToken cancellationToken)
        {
            var wishlist = await _repository.GetByIdAsync(query.ClientId);
            var wishlistProducts = await _repository.GetProductsByClientIdAsync(query.ClientId);

            return new ReadWishlistViewModel(
                id: wishlist.Id,
                clientId: wishlist.ClientId,
                products: _mapper.Map<IList<ReadWishlistProductViewModel>>(wishlistProducts)
            );
        }
    }
}
