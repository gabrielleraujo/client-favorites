using FluentValidation.Results;
using MediatR;
using Newme.ClientFavorites.Application.InputModels.ShoopingCart;

namespace Newme.ClientFavorites.Application.Commands.InsertShoopingCart
{
    public class InsertShoopingCartCommand : ShoopingCartCommand, IRequest<ValidationResult>
    {
        public InsertShoopingCartCommand(
            Guid clientId,
            string? couponName,
            double totalPrice,
            IEnumerable<ReadShoopingCartProductItemInputModel> products) : base(clientId)
        {
            CouponName = couponName;
            TotalPrice = totalPrice;
            Products = products;
        }

        public string? CouponName { get; private set; }
        public double TotalPrice { get; private set; }
        public IEnumerable<ReadShoopingCartProductItemInputModel> Products { get; private set; }

        // public override bool IsValid() 
        // {
        //     ValidationResult = new InsertShoopingCartCommandValidation().Validate(this);
        //     return ValidationResult.IsValid;
        // }
    }
}
