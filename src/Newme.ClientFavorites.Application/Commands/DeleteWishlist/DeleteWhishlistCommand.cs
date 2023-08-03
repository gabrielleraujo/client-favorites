using FluentValidation.Results;
using MediatR;

namespace Newme.ClientFavorites.Application.Commands.DeleteWishlist
{
    public class DeleteWishlistCommand : WishlistCommand, IRequest<ValidationResult>
    {
        public DeleteWishlistCommand(
            Guid clientId,
            Guid productId) : base(clientId)
        {
            ProductId = productId;
        }
        
        public Guid ProductId { get; private set; }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new DeleteWishlistCommandValidation().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
