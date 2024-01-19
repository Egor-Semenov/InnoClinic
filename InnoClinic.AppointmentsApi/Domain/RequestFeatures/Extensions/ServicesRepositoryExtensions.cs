using Domain.Models.Entities;
using Domain.Models.Enums;

namespace Domain.RequestFeatures.Extensions
{
    public static class ServicesRepositoryExtensions
    {
        public static IQueryable<Service> FilterBySpecialization(this IQueryable<Service> services, int specializationId) 
        {
            if (specializationId == 0)
            {
                return services;
            }

            return services.Where(x => x.SpecializationId == specializationId);
        }

        public static IQueryable<Service> FilterByServiceCategory(this IQueryable<Service> services, ServiceCategories category)
        {
            if (category == 0)
            {
                return services;
            }

            return services.Where(x => x.ServiceCategoryId == (int)category);
        }

        public static IQueryable<Service> FilterByServiceStatus(this IQueryable<Service> services, ServiceStatuses status)
        {
            if (status == 0)
            {
                return services;
            }

            return services.Where(x => x.StatusId == (int)status);
        }

        public static IQueryable<Service> Search(this IQueryable<Service> services, string searchTerm) 
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return services;
            }

            return services.Where(x => x.ServiceName.Contains(searchTerm));
        }
    }
}
