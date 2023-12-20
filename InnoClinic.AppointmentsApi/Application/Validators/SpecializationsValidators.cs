using Application.Resourses.Commands.Specializations.ChangeStatus;
using Application.Resourses.Commands.Specializations.Create;
using Application.Resourses.Commands.Specializations.Update;
using FluentValidation;

namespace Application.Validators
{
    public sealed class CreateSpecializationValidator : AbstractValidator<CreateSpecializationCommand>
    {
        public CreateSpecializationValidator() 
        {
            RuleFor(x => x.SpecializationName).NotEmpty().WithMessage("Please, enter the name");
        }
    }

    public sealed class UpdateSpecializationValidator : AbstractValidator<UpdateSpecializationCommand>
    {
        public UpdateSpecializationValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please, enter the id")
               .GreaterThan(0).WithMessage("Id should be positive");
            RuleFor(x => x.SpecializationName).NotEmpty().WithMessage("Please, enter the name");
        }
    }

    public sealed class ChangeSpecializationStatusValidator : AbstractValidator<ChangeSpecializationStatusCommand>
    {
        public ChangeSpecializationStatusValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please, enter the id")
               .GreaterThan(0).WithMessage("Id should be positive");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Please, enter the status");
        }
    }
}
