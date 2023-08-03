using FluentValidation.Results;
using MediatR;

namespace Newme.ClientFavorites.Application.Commands.CleanShoopingCart
{
    public class CleanShoopingCartCommand : ShoopingCartCommand, IRequest<ValidationResult>
    {
        public CleanShoopingCartCommand(Guid clientId) : base(clientId)
        {
        }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new CleanShoopingCartCommandValidation().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
