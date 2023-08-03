using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.ClientFavorites.Domain.Repositories;

namespace Newme.ClientFavorites.Application.Commands.UpdateClientFavoritesAfterProductDeativated
{
    public class UpdateClientFavoritesAfterProductDeativatedCommandHandler : 
        CommandHandler<UpdateClientFavoritesAfterProductDeativatedCommandHandler>,
        IRequestHandler<UpdateClientFavoritesAfterProductDeativatedCommand, ValidationResult>
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IShoopingCartRepository _shoopingCartRepository;

        public UpdateClientFavoritesAfterProductDeativatedCommandHandler(
            ILogger<UpdateClientFavoritesAfterProductDeativatedCommandHandler> logger,
            IWishlistRepository wishlistRepository,
            IShoopingCartRepository shoopingCartRepository) : base(logger)
        {
            _wishlistRepository = wishlistRepository;
            _shoopingCartRepository = shoopingCartRepository;
        }
        
        public async Task<ValidationResult> Handle(UpdateClientFavoritesAfterProductDeativatedCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(UpdateClientFavoritesAfterProductDeativatedCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            var productId = command.Event.ProductId;

            var wishlistProduct = await _wishlistRepository.GetProductByIdAsync(productId);
            wishlistProduct.Deativate();
            await _wishlistRepository.UpdateProduct(wishlistProduct);

            await _shoopingCartRepository.RemoveProductAsync(productId);
            
            _logger.LogInformation($"{nameof(UpdateClientFavoritesAfterProductDeativatedCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
