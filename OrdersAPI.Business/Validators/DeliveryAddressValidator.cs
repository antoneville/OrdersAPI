using FluentValidation;
using OrdersAPI.Models;

namespace OrdersAPI.Business.Validators
{
    public class DeliveryAddressValidator : AbstractValidator<DeliveryAddress>
    {
        public DeliveryAddressValidator()
        {
            RuleFor(x => x.AddressLineOne).NotEmpty().WithMessage("The First Line of the Address must not be empty.");
            RuleFor(x => x.AddressLineTwo).NotEmpty().WithMessage("The Second Line of the Address must not be empty.");
            RuleFor(x => x.Town).NotEmpty().WithMessage("The Town name must not be empty.");
            RuleFor(x => x.County).NotEmpty().WithMessage("The County name must not be empty.");
            RuleFor(x => x.Country).NotEmpty().WithMessage("The Country name must not be empty.");
            RuleFor(x => x.PostCode).NotEmpty().WithMessage("The Post Code name must not be empty.");
        }
    }
}
