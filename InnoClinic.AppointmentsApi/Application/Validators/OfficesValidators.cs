using Application.Resourses.Commands.Offices.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public sealed class CreateOfficeValidator : AbstractValidator<CreateOfficeCommand>
    {
        public CreateOfficeValidator() 
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("");
            RuleFor(x => x.Street).NotEmpty().WithMessage("");
            RuleFor(x => x.City).NotEmpty().WithMessage("");
            RuleFor(x => x.City).NotEmpty().WithMessage("");
            RuleFor(x => x.City).NotEmpty().WithMessage("");
            RuleFor(x => x.City).NotEmpty().WithMessage("");

        }
    }
}
