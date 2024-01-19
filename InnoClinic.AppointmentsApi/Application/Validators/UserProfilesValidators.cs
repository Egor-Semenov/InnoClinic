using Application.Resourses.Commands.Doctors.ChangeStatus;
using Application.Resourses.Commands.Doctors.Create;
using Application.Resourses.Commands.Doctors.Update;
using Application.Resourses.Commands.Patients.Create;
using Application.Resourses.Commands.Patients.Delete;
using Application.Resourses.Commands.Patients.Update;
using Application.Resourses.Commands.Receptionists.Create;
using Application.Resourses.Commands.Receptionists.Delete;
using Application.Resourses.Commands.Receptionists.Update;
using FluentValidation;

namespace Application.Validators
{
    public sealed class DoctorCreationValidator : AbstractValidator<CreateDoctorCommand>
    {
        public DoctorCreationValidator() 
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please, enter the first name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please, enter the last name");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Please, select the date");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please, enter the email")
                .EmailAddress().WithMessage("You've entered an invalid email");
            RuleFor(x => x.SpecializationId).NotEmpty().WithMessage("Please, choose the specialisation");
            RuleFor(x => x.OfficeId).NotEmpty().WithMessage("Please, choose the office");
            RuleFor(x => x.CareerStartYear).NotEmpty().WithMessage("Please, select the year");
        }
    }

    public sealed class DoctorUpdateValidator : AbstractValidator<UpdateDoctorCommand>
    {
        public DoctorUpdateValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please, enter the email")
                .EmailAddress().WithMessage("You've entered an invalid email");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please, enter the first name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please, enter the last name");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Please, select the date");
            RuleFor(x => x.SpecializationId).NotEmpty().WithMessage("Please, choose the specialisation");
            RuleFor(x => x.OfficeId).NotEmpty().WithMessage("Please, choose the office");
            RuleFor(x => x.CareerStartYear).NotEmpty().WithMessage("Please, select the year");
        }
    }

    public sealed class ChangeDoctorStatusValidator : AbstractValidator<ChangeDoctorStatusCommand>
    {
        public ChangeDoctorStatusValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please, enter the id")
                .GreaterThan(0).WithMessage("Id should be positive");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Plese, enter the status");
        }
    }

    public sealed class CreateReceptionistValidator : AbstractValidator<CreateReceptionistCommand>
    {
        public CreateReceptionistValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please, enter the first name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please, enter the last name");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please, enter the email")
                .EmailAddress().WithMessage("You've entered an invalid email");
            RuleFor(x => x.OfficeId).NotEmpty().WithMessage("Please, choose the office");
        }
    }

    public sealed class UpdateReceptionistValidator : AbstractValidator<UpdateReceptionistCommand>
    {
        public UpdateReceptionistValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Please, enter the email")
                .EmailAddress().WithMessage("You've entered an invalid email");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please, enter the first name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please, enter the last name");
            RuleFor(x => x.OfficeId).NotEmpty().WithMessage("Please, choose the office");
        }
    }

    public sealed class DeleteReceptionistValidator : AbstractValidator<DeleteReceptionistCommand>
    {
        public DeleteReceptionistValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please, enter the id")
                .GreaterThan(0).WithMessage("Id should be positive");
        }
    }

    public sealed class CreatePatientValidator : AbstractValidator<CreatePatientCommand>
    {
        public CreatePatientValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please, enter the first name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please, enter the last name");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Please, select the date");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Please, enter the phone number")
                .Matches(@"^[0-9+]+$").WithMessage("You've entered an invalid phone number");
        }
    }

    public sealed class UpdatePatientValidator : AbstractValidator<UpdatePatientCommand>
    {
        public UpdatePatientValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please, enter the id")
                .GreaterThan(0).WithMessage("Id should be positive");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Please, enter the first name");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Please, enter the last name");
            RuleFor(x => x.BirthDate).NotEmpty().WithMessage("Please, select the date");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Please, enter the phone number")
                .Matches(@"^[0-9+]+$").WithMessage("You've entered an invalid phone number");
        }
    }

    public sealed class DeletePatientValidator : AbstractValidator<DeletePatientCommand>
    {
        public DeletePatientValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Please, enter the id")
                .GreaterThan(0).WithMessage("Id should be positive");
        }
    }
}
