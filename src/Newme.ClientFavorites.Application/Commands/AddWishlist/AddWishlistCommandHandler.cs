using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.ClientFavorites.Domain.Entities.Wishlist;
using Newme.ClientFavorites.Domain.Repositories;
using AutoMapper;

namespace Newme.ClientFavorites.Application.Commands.AddWishlist
{
    public class AddWishlistCommandHandler : 
        CommandHandler<AddWishlistCommandHandler>,
        IRequestHandler<AddWishlistCommand, ValidationResult>
    {
        private readonly IMapper _mapper;
        private readonly IWishlistRepository _repository;

        public AddWishlistCommandHandler(
            ILogger<AddWishlistCommandHandler> logger,
            IMapper mapper,
            IWishlistRepository repository) : base(logger)
        {
            _mapper = mapper;
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(AddWishlistCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(AddWishlistCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var product = _mapper.Map<WishlistProduct>(command.Product);
            var productItem = new WishlistProductItem(command.ClientId, product.ProductId);

            var wishlist = await _repository.GetByIdAsync(command.ClientId);

            if (wishlist == null)
            {
                wishlist = new Wishlist(
                    id: Guid.NewGuid(),
                    clientId: command.ClientId,
                    products: new List<WishlistProductItem>() { productItem }
                );
                await _repository.AddAsync(wishlist);
                _logger.LogInformation("Created wishlist for client id: {clientId}.", command.ClientId);

                return ValidationResult;
            }
            
            var wishlistProductResponse = await _repository.GetProductByIdAsync(product.ProductId);
            if (wishlistProductResponse == null)
            {
                await _repository.AddProductAsync(product);
                _logger.LogInformation("Poduct id: {productId} added to wishlist products.", product.ProductId);
            }
            if (!wishlist.HasProduct(command.Product.ProductId))
            {
                await _repository.AddProductItemAsync(new WishlistProductItem(command.ClientId, product.ProductId));
                _logger.LogInformation("Poduct id: {productId} added to client {clientId}.", product.ProductId, command.ClientId);
            }
 
            _logger.LogInformation($"{nameof(AddWishlistCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
