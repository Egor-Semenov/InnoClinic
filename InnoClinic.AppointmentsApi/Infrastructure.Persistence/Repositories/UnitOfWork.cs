using Domain.Interfaces.Repositories;
using Domain.Models.Entities;
using Infrastructure.Persistence.Contexts;

namespace Infrastructure.Persistence.Repositories
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IPatientRepository PatientsRepository { get; }
        public IDoctorRepository DoctorsRepository { get; }
        public IReceptionistRepository ReceptionistsRepository { get; }
        public ISpecializationRepository SpecializationsRepository { get; }
        public IServiceRepository ServicesRepository { get; }
        public IAppointmentRepository AppointmentsRepository { get; }
        public ILogRepository LogsRepository { get; }

        public UnitOfWork(
            ApplicationDbContext dbContext,
            IPatientRepository patientsRepository,
            IDoctorRepository doctorsRepository,
            IReceptionistRepository receptionistsRepository,
            ISpecializationRepository specializationsRepository,
            IServiceRepository servicesRepository,
            IAppointmentRepository appointmentsRepository,
            ILogRepository logsRepository)
        {
            _dbContext = dbContext;
            PatientsRepository = patientsRepository;
            DoctorsRepository = doctorsRepository;
            ReceptionistsRepository = receptionistsRepository;
            SpecializationsRepository = specializationsRepository;
            ServicesRepository = servicesRepository;
            AppointmentsRepository = appointmentsRepository;
            LogsRepository = logsRepository;
        }

        public async Task SaveChangesAsync(CancellationToken token = default)
        {
            await _dbContext.SaveChangesAsync(token);
        }

        public void Rollback()
        {
            _dbContext.ChangeTracker.Clear();
        }
    }
}
