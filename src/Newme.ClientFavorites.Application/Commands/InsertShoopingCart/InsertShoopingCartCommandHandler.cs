using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;
using Newme.ClientFavorites.Domain.Repositories;
using AutoMapper;

namespace Newme.ClientFavorites.Application.Commands.InsertShoopingCart
{
    public class InsertShoopingCartCommandHandler : 
        CommandHandler<InsertShoopingCartCommandHandler>,
        IRequestHandler<InsertShoopingCartCommand, ValidationResult>
    {
        private readonly IMapper _mapper;
        private readonly IShoopingCartRepository _repository;
        private readonly IDiscountCouponRepository _couponRepository;

        public InsertShoopingCartCommandHandler(
            ILogger<InsertShoopingCartCommandHandler> logger,
            IMapper mapper,
            IShoopingCartRepository repository,
            IDiscountCouponRepository couponRepository) : base(logger)
        {
            _mapper = mapper;
            _repository = repository;
            _couponRepository = couponRepository;
        }
        
        public async Task<ValidationResult> Handle(InsertShoopingCartCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(InsertShoopingCartCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var products = _mapper.Map<IEnumerable<ShoopingCartProduct>>(command.Products).ToList();
            var shoopingCart = await _repository.GetByIdAsync(command.ClientId);

            Guid? couponId = null;
            if (command.CouponName != null)
            {
                var coupon = await _couponRepository.GetByNameAsync(command.CouponName);
                couponId = coupon.Id;
            }

            if (shoopingCart == null)
            {
                shoopingCart = new ShoopingCart(
                    id: Guid.NewGuid(),
                    clientId: command.ClientId, 
                    couponId: couponId,
                    totalPrice: command.TotalPrice,
                    products: products
                );
                await _repository.AddAsync(shoopingCart);
                _logger.LogInformation("Created shooping cart for client id: {clientId}.", command.ClientId);
            }
            else {
                await _repository.UpdateAsync(shoopingCart);
            }

            _logger.LogInformation($"{nameof(InsertShoopingCartCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
