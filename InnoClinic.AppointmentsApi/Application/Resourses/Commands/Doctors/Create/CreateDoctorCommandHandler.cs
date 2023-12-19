using Application.DTOs.Doctors;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Doctors.Create
{
    public sealed class CreateDoctorCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
    {
        private readonly IBaseRepository<Doctor> _doctorsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDoctorCommandHandler(IBaseRepository<Doctor> doctorsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _doctorsRepository = doctorsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
        {
            var doctor = new Doctor
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                MiddleName = request.MiddleName,
                BirthDate = request.BirthDate,
                Email = request.Email,
                SpecializationId = request.SpecializationId,
                OfficeId = request.OfficeId,
                CareerStartYear = request.CareerStartYear,
                StatusId = (int)request.Status,
                PhotoFilePath = request.PhotoFilePath
            };

            _doctorsRepository.Create(doctor);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DoctorDto>(doctor);
        }
    }
}
