using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Newme.ClientFavorites.Application.ViewModels.ShoopingCart;
using Newme.ClientFavorites.Domain.Entities.ShoopingCart;
using Newme.ClientFavorites.Domain.Repositories;
using OneOf;

namespace Newme.ClientFavorites.Application.Commands.CalculateDiscountCoupon
{
    public class CalculateDiscountCouponQueryHandler : IRequestHandler<CalculateDiscountCouponQuery, OneOf<ReadShoppingCartViewModel, string>>
    {
        private ILogger<CalculateDiscountCouponQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IShoopingCartRepository _repository;
        private readonly IDiscountCouponRepository _repositoryCoupon;

        public CalculateDiscountCouponQueryHandler(
            ILogger<CalculateDiscountCouponQueryHandler> logger,
            IMapper mapper,
            IShoopingCartRepository repository,
            IDiscountCouponRepository repositoryCoupon)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
            _repositoryCoupon = repositoryCoupon;
        }
        
        public async Task<OneOf<ReadShoppingCartViewModel, string>> Handle(CalculateDiscountCouponQuery query, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(CalculateDiscountCouponQueryHandler)} starting");

            var coupon = await _repositoryCoupon.GetByNameAsync(query.Coupon);

            if (coupon == null)
            {
                _logger.LogInformation("Coupon not found.");
                return "O cupom não foi encontrado.";
            }

            var shoopingCart = new ShoopingCart(
                    id: Guid.NewGuid(),
                    clientId: query.ClientId, 
                    couponId: coupon.Id,
                    totalPrice: query.TotalPrice,
                    products: _mapper.Map<IList<ShoopingCartProduct>>(query.Products)
                );

            shoopingCart.ApplyDiscountCoupon(coupon);

            _logger.LogInformation($"{nameof(CalculateDiscountCouponQueryHandler)} successfully completed");

            return _mapper.Map<ReadShoppingCartViewModel>(shoopingCart);
        }
    }
}
