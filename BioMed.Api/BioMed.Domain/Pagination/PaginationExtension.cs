using BioMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BioMed.Domain.Pagination
{
    public static class PaginationExtension
    {
        public static PaginatedList<T> ToPaginatedList<T>(
            this IQueryable<T> source,
            int pageSize,
            int pageNumber) where T : EntityBase
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
