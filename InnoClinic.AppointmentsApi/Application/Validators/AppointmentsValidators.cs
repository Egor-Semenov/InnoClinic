using Application.Resourses.Commands.Appointments.Create;
using FluentValidation;

namespace Application.Validators
{
    public sealed class CreateAppointmentValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentValidator() 
        {
            RuleFor(x => x.DoctorId).NotEmpty().WithMessage("Please, choose the doctor");
            RuleFor(x => x.PatientId).NotEmpty().WithMessage("Please, choose the patient");
            RuleFor(x => x.SpecializationId).NotEmpty().WithMessage("Please, choose the specialization");
            RuleFor(x => x.ServiceId).NotEmpty().WithMessage("Please, choose the service");
            RuleFor(x => x.OfficeId).NotEmpty().WithMessage("Please, choose the office");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Please, choose the date");
            RuleFor(x => x.Time).NotEmpty().WithMessage("Please, choose the time");
        }
    }
}
