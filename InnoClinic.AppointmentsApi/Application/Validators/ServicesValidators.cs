using Application.Resourses.Commands.Services.ChangeStatus;
using Application.Resourses.Commands.Services.Create;
using Application.Resourses.Commands.Services.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public sealed class CreateServiceValidator : AbstractValidator<CreateServiceCommand>
    {
        public CreateServiceValidator()
        {
            RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Please, enter the name");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Please, enter the price");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Please, choose the service category");
        }
    }

    public sealed class UpdateServiceValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please, enter the id")
               .GreaterThan(0).WithMessage("Id should be positive");
            RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Please, enter the name");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Please, enter the price");
            RuleFor(x => x.Category).NotEmpty().WithMessage("Please, choose the service category");
        }
    }

    public sealed class ChangeServiceStatusValidator : AbstractValidator<ChangeServiceStatusCommand>
    {
        public ChangeServiceStatusValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please, enter the id")
               .GreaterThan(0).WithMessage("Id should be positive");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Please, enter the status");
        }
    }
}
