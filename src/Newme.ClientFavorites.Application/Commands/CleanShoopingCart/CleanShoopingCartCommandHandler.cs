using MediatR;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Newme.ClientFavorites.Domain.Repositories;

namespace Newme.ClientFavorites.Application.Commands.CleanShoopingCart
{
    public class CleanShoopingCartCommandHandler : 
        CommandHandler<CleanShoopingCartCommandHandler>,
        IRequestHandler<CleanShoopingCartCommand, ValidationResult>
    {
        private readonly IShoopingCartRepository _repository;

        public CleanShoopingCartCommandHandler(
            ILogger<CleanShoopingCartCommandHandler> logger,
            IShoopingCartRepository repository) : base(logger)
        {
            _repository = repository;
        }
        
        public async Task<ValidationResult> Handle(CleanShoopingCartCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"{nameof(CleanShoopingCartCommandHandler)} starting");

            if (!command.IsValid())
            {
                AddError("Command model is invalid");
                return command.ValidationResult;
            }

            await _repository.CleanByIdAsync(command.ClientId);

            _logger.LogInformation($"{nameof(CleanShoopingCartCommandHandler)} successfully completed");

            return ValidationResult;
        }
    }
}
