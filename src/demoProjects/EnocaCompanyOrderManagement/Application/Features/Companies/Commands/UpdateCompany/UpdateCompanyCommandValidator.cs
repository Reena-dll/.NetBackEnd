using Application.Features.Companies.Commands.CreateCompany;
using Application.Features.Companies.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Companies.Commands.UpdateCompany
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
            RuleFor(c => c.Name).MaximumLength(50);
            RuleFor(c => c.Name).NotNull();
            RuleFor(c => c.OrderFinishDate).NotNull();
            RuleFor(c => c.OrderFinishDate).NotEmpty();
            RuleFor(c => c.OrderStartDate).NotEmpty();
            RuleFor(c => c.OrderStartDate).NotNull();
        }
    }
}
