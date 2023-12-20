using Application.Resourses.Commands.Offices.ChangeStatus;
using Application.Resourses.Commands.Offices.Create;
using Application.Resourses.Commands.Offices.Update;
using FluentValidation;

namespace Application.Validators
{
    public sealed class CreateOfficeValidator : AbstractValidator<CreateOfficeCommand>
    {
        public CreateOfficeValidator() 
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("Please, enter the office’s city");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Please, enter the office’s street");
            RuleFor(x => x.HouseNumber).NotEmpty().WithMessage("Please, enter the office’s house number");
            RuleFor(x => x.OfficeNumber).NotEmpty()
                .When(x => x.OfficeNumber != null).WithMessage("Please, enter the office’s number");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Please, enter the phone number")
                .Matches(@"^[0-9+]+$").WithMessage("You've entered an invalid phone number");
        }
    }

    public sealed class UpdateOfficeValidator : AbstractValidator<UpdateOfficeCommand>
    {
        public UpdateOfficeValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("Please, enter the office’s city");
            RuleFor(x => x.Street).NotEmpty().WithMessage("Please, enter the office’s street");
            RuleFor(x => x.HouseNumber).NotEmpty().WithMessage("Please, enter the office’s house number");
            RuleFor(x => x.OfficeNumber).NotEmpty()
                .When(x => x.OfficeNumber != null).WithMessage("Please, enter the office’s number");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Please, enter the phone number")
                .Matches(@"^[0-9+]+$").WithMessage("You've entered an invalid phone number");
        }
    }

    public sealed class ChangeOfficeStatusValidator : AbstractValidator<ChangeOfficeStatusCommand>
    {
        public ChangeOfficeStatusValidator()
        {
            RuleFor(x => x.Status).NotEmpty().WithMessage("Please, enter the status");
        }
    }
}
