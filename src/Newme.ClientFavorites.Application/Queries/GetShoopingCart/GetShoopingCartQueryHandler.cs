using MediatR;
using Newme.ClientFavorites.Domain.Repositories;
using Newme.ClientFavorites.Application.ViewModels.ShoopingCart;
using AutoMapper;

namespace Newme.ClientFavorites.Application.Commands.GetShoopingCart
{
    public class GetShoopingCartQueryHandler : IRequestHandler<GetShoopingCartQuery, ReadShoppingCartViewModel>
    {
        private readonly IMapper _mapper;
        private readonly IShoopingCartRepository _repository;

        public GetShoopingCartQueryHandler(
            IMapper mapper,
            IShoopingCartRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public async Task<ReadShoppingCartViewModel> Handle(GetShoopingCartQuery query, CancellationToken cancellationToken)
        {
            var shoopingCart = await _repository.GetByIdAsync(query.ClientId);
            return _mapper.Map<ReadShoppingCartViewModel>(shoopingCart);
        }
    }
}
