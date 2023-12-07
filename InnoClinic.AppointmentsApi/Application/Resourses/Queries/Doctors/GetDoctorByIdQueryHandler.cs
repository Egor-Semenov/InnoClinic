using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Resourses.Queries.Doctors
{
    public sealed class GetDoctorByIdQueryHandler : IRequestHandler<GetDoctorByIdQuery, Doctor>
    {
        private readonly IBaseRepository<Doctor> _doctorsRepository;

        public GetDoctorByIdQueryHandler(IBaseRepository<Doctor> doctorsRepository)
        {
            _doctorsRepository = doctorsRepository;
        }

        public async Task<Doctor> Handle(GetDoctorByIdQuery request, CancellationToken cancellationToken) =>
            await _doctorsRepository.FindByCondition(x => x.Id == request.Id, false).FirstOrDefaultAsync();
    }
}
