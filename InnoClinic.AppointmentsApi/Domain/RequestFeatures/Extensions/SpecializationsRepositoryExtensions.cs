using Domain.Models.Entities;
using Domain.Models.Enums;

namespace Domain.RequestFeatures.Extensions
{
    public static class SpecializationsRepositoryExtensions
    {
        public static IQueryable<Specialization> FilterBySpecializationStatus(this IQueryable<Specialization> specializations, SpecializationStatuses status) 
        {
            if (status == 0)
            {
                return specializations;
            }

            return specializations.Where(x => x.StatusId == (int)status);
        }

        public static IQueryable<Specialization> Search(this IQueryable<Specialization> specializations, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return specializations;
            }

            return specializations.Where(x => x.SpecializationName.Contains(searchTerm));
        }
    }
}
