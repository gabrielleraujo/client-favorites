using FluentValidation.Results;
using Newme.ClientFavorites.Application.InputModels.Wishlist;
using AutoMapper;
using MediatR;
using Newme.ClientFavorites.Application.ViewModels.Wishlist;
using Newme.ClientFavorites.Application.Commands.DeleteWishlist;
using Newme.ClientFavorites.Application.Commands.AddWishlist;
using Newme.ClientFavorites.Application.Commands.GetWishlist;

namespace Newme.ClientFavorites.Application.Services
{
    public class WishlistService : IWishlistService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public WishlistService(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ValidationResult> AddAsync(AddWishlistInputModel inputModel)
        {
            return await _mediator.Send(_mapper.Map<AddWishlistCommand>(inputModel));
        }

        public async Task<ValidationResult> DeleteAsync(DeleteWishlistInputModel inputModel)
        {
            return await _mediator.Send(_mapper.Map<DeleteWishlistCommand>(inputModel));
        }

        public async Task<ReadWishlistViewModel> GetAsync(Guid clientId)
        {
            return await _mediator.Send(new GetWishlistQuery(clientId: clientId));
        }
    }
}
