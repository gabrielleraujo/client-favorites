using FluentValidation.Results;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;
using AutoMapper;
using MediatR;
using Newme.ClientFavorites.Application.ViewModels.ShoopingCart;
using Newme.ClientFavorites.Application.Commands.InsertShoopingCart;
using Newme.ClientFavorites.Application.Commands.GetShoopingCart;
using Newme.ClientFavorites.Application.Commands.CalculateDiscountCoupon;
using OneOf;
using Newme.ClientFavorites.Application.Commands.CleanShoopingCart;

namespace Newme.ClientFavorites.Application.Services
{
    public class ShoopingCartService : IShoopingCartService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ShoopingCartService(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ValidationResult> CleanAsync(Guid clientId)
        {
            return await _mediator.Send(new CleanShoopingCartCommand(clientId));
        }

        public async Task<ValidationResult> UpsertAsync(InsertShoopingCartInputModel inputModel)
        {
            return await _mediator.Send(_mapper.Map<InsertShoopingCartCommand>(inputModel));
        }

        public async Task<ReadShoppingCartViewModel> GetAsync(Guid clientId)
        {
            return await _mediator.Send(new GetShoopingCartQuery(clientId: clientId));
        }

        public async Task<OneOf<ReadShoppingCartViewModel, string>> CalculateDiscountCouponAsync(CalculateDiscountCouponInputModel inputModel)
        {
            return await _mediator.Send(_mapper.Map<CalculateDiscountCouponQuery>(inputModel));
        }
    }
}
