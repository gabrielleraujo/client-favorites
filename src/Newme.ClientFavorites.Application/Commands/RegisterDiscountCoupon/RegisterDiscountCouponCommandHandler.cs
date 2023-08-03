using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Logging;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;
using Newme.ClientFavorites.Domain.Repositories;

namespace Newme.ClientFavorites.Application.Commands.RegisterDiscountCoupon
{
    public class RegisterDiscountCouponCommandHandler : 
        CommandHandler<RegisterDiscountCouponCommandHandler>,
        IRequestHandler<RegisterDiscountCouponCommand, ValidationResult>
    {
        private readonly IMapper _mapper;
        private readonly IDiscountCouponRepository _repository;

        public RegisterDiscountCouponCommandHandler(
            ILogger<RegisterDiscountCouponCommandHandler> logger,
            IMapper mapper,
            IDiscountCouponRepository repository) : base(logger)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(RegisterDiscountCouponCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(RegisterDiscountCouponCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var response = await _repository.GetByNameAsync(command.Name);

            if (response != null)
            {
                AddError("Coupon name: {name} already exist.");
                return ValidationResult;
            }

            var discountCoupon = new DiscountCoupon(
                id: Guid.NewGuid(),
                name: command.Name,
                percentage: command.Percentage,
                description: command.Description
            );
 
            await _repository.AddAsync(discountCoupon);

            _logger.LogInformation($"{nameof(RegisterDiscountCouponCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}