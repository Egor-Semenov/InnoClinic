using Application.DTOs.Patients;
using AutoMapper;
using Domain.Exceptions;
using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Commands.Patients.Delete
{
    public sealed class DeletePatientCommandHandler : IRequestHandler<DeletePatientCommand, DeletePatientDto>
    {
        private readonly IBaseRepository<Patient> _patientsRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePatientCommandHandler(IBaseRepository<Patient> patientsRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _patientsRepository = patientsRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<DeletePatientDto> Handle(DeletePatientCommand request, CancellationToken cancellationToken)
        {
            var patient = await _patientsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();
            if (patient is null)
            {
                throw new NotFoundException($"Patient with id: {request.Id} is not found.");
            }

            _patientsRepository.Delete(patient);
            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<DeletePatientDto>(patient);
        }
    }
}
