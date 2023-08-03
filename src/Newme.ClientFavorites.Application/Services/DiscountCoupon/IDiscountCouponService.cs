using FluentValidation.Results;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;

namespace Newme.ClientFavorites.Application.Services
{
    public interface IDiscountCouponService
    {
        //Task<ValidationResult> DeleteAsync(Guid id);
        Task<ValidationResult> RegisterAsync(RegisterDiscountCouponInputModel inputModel);
    }
}
