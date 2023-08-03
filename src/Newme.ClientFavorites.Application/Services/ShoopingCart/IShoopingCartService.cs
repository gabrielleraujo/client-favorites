using FluentValidation.Results;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;
using Newme.ClientFavorites.Application.ViewModels.ShoopingCart;
using OneOf;

namespace Newme.ClientFavorites.Application.Services
{
    public interface IShoopingCartService
    {
        Task<ValidationResult> CleanAsync(Guid clientId);
        Task<ValidationResult> UpsertAsync(InsertShoopingCartInputModel inputModel);
        Task<ReadShoppingCartViewModel> GetAsync(Guid clientId);
        Task<OneOf<ReadShoppingCartViewModel, string>> CalculateDiscountCouponAsync(CalculateDiscountCouponInputModel inputModel);
    }
}