using Application.Features.Companies.Commands.CreateCompany;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.Name).MaximumLength(100);
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.Price).GreaterThan(0);
            RuleFor(c => c.Price).NotNull();
            RuleFor(c => c.Price).NotEmpty();
            RuleFor(c => c.CompanyId).NotEmpty();
            RuleFor(c => c.CompanyId).NotNull();
            RuleFor(c => c.Stock).GreaterThan(0);
            RuleFor(c => c.Stock).NotNull();
            RuleFor(c => c.Stock).NotEmpty();         
        }
    }
}
