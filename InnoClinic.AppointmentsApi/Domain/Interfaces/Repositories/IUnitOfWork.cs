using Domain.Models.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientsRepository { get; }
        IDoctorRepository DoctorsRepository { get; }
        IReceptionistRepository ReceptionistsRepository { get; }
        ISpecializationRepository SpecializationsRepository { get; }
        IServiceRepository ServicesRepository { get; }
        IAppointmentRepository AppointmentsRepository { get; }
        ILogRepository LogsRepository { get; }

        Task SaveChangesAsync(CancellationToken token = default);
        void Rollback();
    }
}
