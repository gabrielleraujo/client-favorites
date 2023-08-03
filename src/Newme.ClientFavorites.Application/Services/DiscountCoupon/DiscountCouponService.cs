using FluentValidation.Results;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;
using AutoMapper;
using MediatR;
using Newme.ClientFavorites.Application.Commands.RegisterDiscountCoupon;

namespace Newme.ClientFavorites.Application.Services
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public DiscountCouponService(
            IMapper mapper,
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        // public async Task<ValidationResult> DeleteAsync(Guid id)
        // {
        //     return await _mediator.Send(new DeleteDiscountCouponCommand(id));
        // }

        public async Task<ValidationResult> RegisterAsync(RegisterDiscountCouponInputModel inputModel)
        {
            return await _mediator.Send(_mapper.Map<RegisterDiscountCouponCommand>(inputModel));
        }
    }
}
