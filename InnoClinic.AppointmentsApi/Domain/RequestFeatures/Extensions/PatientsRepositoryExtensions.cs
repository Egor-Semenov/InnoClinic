using Domain.Models.Entities;

namespace Domain.RequestFeatures.Extensions
{
    public static class PatientsRepositoryExtensions
    {
        public static IQueryable<Patient> Search(this IQueryable<Patient> patients, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return patients;
            }

            return patients.Where(x => x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm));
        }
    }
}
