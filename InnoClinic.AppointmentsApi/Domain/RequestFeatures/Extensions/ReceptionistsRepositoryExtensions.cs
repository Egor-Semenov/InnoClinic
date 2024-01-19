using Domain.Models.Entities;

namespace Domain.RequestFeatures.Extensions
{
    public static class ReceptionistsRepositoryExtensions
    {
        public static IQueryable<Receptionist> FilterByOffice(this IQueryable<Receptionist> receptionists, int officeId)
        {
            if (officeId == 0)
            {
                return receptionists;
            }

            return receptionists.Where(x => x.OfficeId == officeId);
        }

        public static IQueryable<Receptionist> Search(this IQueryable<Receptionist> receptionists, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return receptionists;
            }

            return receptionists.Where(x => x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm));
        }
    }
}
