using Application.Resourses.Commands.Doctors.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
