using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EShop.Entities.Concrete;
using FluentValidation;

namespace EShop.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            string message = "This column should not be empty.";
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage(message);
            RuleFor(c => c.Description).NotEmpty().WithMessage(message);

            RuleFor(c => c.CategoryName).Must(NotStartWith).WithMessage("Please, enter the category name correctly!");
            RuleFor(c => c.Description).Must(NotStartWith).WithMessage("Please, enter the description correctly!");
        }

        private bool NotStartWith(string text)
        {
            return (!(text.StartsWith("Ğ") | text.StartsWith("I") | text.StartsWith("ğ") | text.StartsWith("ı")));
        }
    }
}
