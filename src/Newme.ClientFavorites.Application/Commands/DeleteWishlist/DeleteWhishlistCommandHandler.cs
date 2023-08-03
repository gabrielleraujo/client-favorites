using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.ClientFavorites.Domain.Repositories;

namespace Newme.ClientFavorites.Application.Commands.DeleteWishlist
{
    public class DeleteWishlistCommandHandler : 
        CommandHandler<DeleteWishlistCommandHandler>,
        IRequestHandler<DeleteWishlistCommand, ValidationResult>
    {
        private readonly IWishlistRepository _repository;

        public DeleteWishlistCommandHandler(
            ILogger<DeleteWishlistCommandHandler> logger,
            IWishlistRepository repository) : base(logger)
        {
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(DeleteWishlistCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(DeleteWishlistCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            await _repository.RemoveProductAsync(command.ClientId, command.ProductId);

            _logger.LogInformation($"{nameof(DeleteWishlistCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
