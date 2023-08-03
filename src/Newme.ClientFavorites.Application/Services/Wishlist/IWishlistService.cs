using FluentValidation.Results;
using Newme.ClientFavorites.Application.InputModels.Wishlist;
using Newme.ClientFavorites.Application.ViewModels.Wishlist;

namespace Newme.ClientFavorites.Application.Services
{
    public interface IWishlistService
    {
        Task<ValidationResult> AddAsync(AddWishlistInputModel inputModel);
        Task<ValidationResult> DeleteAsync(DeleteWishlistInputModel inputModel);
        Task<ReadWishlistViewModel> GetAsync(Guid clientId);
    }
}
