using Domain.Models.Entities;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestFeatures.Extensions
{
    public static class DoctorsRepositoryExtensions
    {
        public static IQueryable<Doctor> FilterBySpecializationType(this IQueryable<Doctor> doctors, int specializationType) 
        {
            if (specializationType == 0)
            {
                return doctors;
            }

            return doctors.Where(x => x.SpecializationId == specializationType);
        }

        public static IQueryable<Doctor> FilterByDoctorStatus(this IQueryable<Doctor> doctors, DoctorsStatuses status)
        {
            if (status == 0)
            {
                return doctors;
            }

            return doctors.Where(x => x.StatusId == (int)status);
        }

        public static IQueryable<Doctor> FilterByOffice(this IQueryable<Doctor> doctors, int officeId)
        {
            if (officeId == 0)
            {
                return doctors;
            }

            return doctors.Where(x => x.OfficeId == officeId);
        }

        public static IQueryable<Doctor> Search(this IQueryable<Doctor> doctors, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm)) 
            {
                return doctors;
            }

            return doctors.Where(x => x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm));
        }
    }
}
