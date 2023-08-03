using FluentValidation.Results;
using MediatR;
using Newme.ClientFavorites.Application.InputModels.Wishlist;

namespace Newme.ClientFavorites.Application.Commands.AddWishlist
{
    public class AddWishlistCommand : WishlistCommand, IRequest<ValidationResult>
    {
        public AddWishlistCommand(
            Guid clientId,
            ReadWishlistProductItemInputModel product) : base(clientId)
        {
            Product = product;
        }

        public ReadWishlistProductItemInputModel Product { get; set; }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new AddWishlistCommandValidation().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
