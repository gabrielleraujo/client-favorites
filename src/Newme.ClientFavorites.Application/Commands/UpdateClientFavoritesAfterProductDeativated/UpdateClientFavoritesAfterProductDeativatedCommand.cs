using FluentValidation.Results;
using MediatR;
using Newme.ClientFavorites.Application.Subscribers.Events;

namespace Newme.ClientFavorites.Application.Commands.UpdateClientFavoritesAfterProductDeativated
{
    public class UpdateClientFavoritesAfterProductDeativatedCommand : Command, IRequest<ValidationResult>
    {
        public UpdateClientFavoritesAfterProductDeativatedCommand(
            DeactivatedProductReceivedEvent @event)
        {
            Event = @event;
        }

        public DeactivatedProductReceivedEvent Event { get; set; }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new DeleteShoopingCartCommandValidation().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
