using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.CompanyId).NotNull();
            RuleFor(x => x.CompanyId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.UserId).NotNull();
            RuleFor(x => x.OrderDate).NotNull();
            RuleFor(x => x.OrderDate).NotEmpty();
        }
    }
}
