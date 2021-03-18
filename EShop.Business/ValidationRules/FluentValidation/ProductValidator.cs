using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Entities.Concrete;
using FluentValidation;

namespace EShop.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            string message = "This column should not be empty.";

            RuleFor(p => p.ProductName).NotEmpty().WithMessage(message);
            RuleFor(p => p.CategoryName).NotEmpty().WithMessage(message);
            RuleFor(p => p.UnitPrice).NotEmpty().WithMessage(message);
            RuleFor(p => p.QuantityProduct).NotEmpty().WithMessage(message);
            RuleFor(p => p.AmountStock).NotEmpty().WithMessage(message);

            RuleFor(p => p.UnitPrice).GreaterThan(0)
                .WithMessage("The product price can not be 0 and less than 0.");
            RuleFor(p => p.AmountStock).GreaterThan(0)
                .WithMessage("The amount stock can not be 0 and less than 0.");

            RuleFor(p => p.ProductName).Must(NotStartWith).WithMessage("Please, enter the product name correctly!");
            RuleFor(p => p.CategoryName).Must(NotStartWith).WithMessage("Please, enter the category name correctly!");
            RuleFor(p => p.QuantityProduct).Must(NotStartWith).WithMessage("Please, enter the product quantity correctly!");
        }

        private bool NotStartWith(string text)
        {
            return (!(text.StartsWith("Ğ") | text.StartsWith("I") | text.StartsWith("ğ") | text.StartsWith("ı")));
        }
    }
}
