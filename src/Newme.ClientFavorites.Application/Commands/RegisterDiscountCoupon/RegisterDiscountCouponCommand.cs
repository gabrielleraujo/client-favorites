using FluentValidation.Results;
using MediatR;

namespace Newme.ClientFavorites.Application.Commands.RegisterDiscountCoupon
{
    public class RegisterDiscountCouponCommand : Command, IRequest<ValidationResult>
    {
        public RegisterDiscountCouponCommand(
            string name, 
            double percentage, 
            string description)
        {
            Name = name;
            Percentage = percentage;
            Description = description;
        }

        public string Name { get; private set; }
        public double Percentage { get; private set; }
        public string Description { get; private set; }
    }
}
