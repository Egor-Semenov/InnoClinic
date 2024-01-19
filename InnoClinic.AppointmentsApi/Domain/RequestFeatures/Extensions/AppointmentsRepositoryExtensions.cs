using Domain.Models.Entities;
using Domain.Models.Enums;

namespace Domain.RequestFeatures.Extensions
{
    public static class AppointmentsRepositoryExtensions
    {
        public static IQueryable<Appointment> FilterByPatient(this IQueryable<Appointment> appointments, int patientId)
        {
            if (patientId == 0)
            {
                return appointments;
            }

            return appointments.Where(x => x.PatientId == patientId);
        }

        public static IQueryable<Appointment> FilterByDoctor(this IQueryable<Appointment> appointments, int doctorId)
        {
            if (doctorId == 0)
            {
                return appointments;
            }

            return appointments.Where(x => x.DoctorId == doctorId);
        }

        public static IQueryable<Appointment> FilterBySpecialization(this IQueryable<Appointment> appointments, int specializationId)
        {
            if (specializationId == 0)
            {
                return appointments;
            }

            return appointments.Where(x => x.SpecializationId == specializationId);
        }

        public static IQueryable<Appointment> FilterByService(this IQueryable<Appointment> appointments, int serviceId)
        {
            if (serviceId == 0)
            {
                return appointments;
            }

            return appointments.Where(x => x.ServiceId == serviceId);
        }

        public static IQueryable<Appointment> FilterByOffice(this IQueryable<Appointment> appointments, int officeId)
        {
            if (officeId == 0)
            {
                return appointments;
            }

            return appointments.Where(x => x.OfficeId == officeId);
        }

        public static IQueryable<Appointment> FilterByAppointmentStatus(this IQueryable<Appointment> appointments, AppointmentsStatuses status)
        {
            if (status == 0)
            {
                return appointments;
            }

            return appointments.Where(x => x.StatusId == (int)status);
        }
    }
}
