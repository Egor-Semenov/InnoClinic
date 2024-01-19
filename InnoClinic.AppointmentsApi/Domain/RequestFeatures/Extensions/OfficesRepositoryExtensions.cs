using Domain.Models.Entities;
using Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RequestFeatures.Extensions
{
    public static class OfficesRepositoryExtensions
    {
        public static IQueryable<Office> FilterByOfficeStatus(this IQueryable<Office> offices, OfficeStatuses status) 
        {
            if (status == 0)
            {
                return offices;
            }

            return offices.Where(x => x.StatusId == (int)status);
        }

        public static IQueryable<Office> Search(this IQueryable<Office> offices, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return offices;
            }

            return offices.Where(x => 
                x.City.Contains(searchTerm) ||
                x.Street.Contains(searchTerm) ||
                x.HouseNumber.Contains(searchTerm));
        }
    }
}
