using BioMed.Domain.DTOs.Visit;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface IVisitService
    {
        PaginatedList<VisitDTO> GetVisits(VisitResourceParameters visitResourceParameters);
        VisitDTO? GetVisitById(int id);
        VisitDTO CreateVisit(VisitForCreateDTO visitToCreate);
        void UpdateVisit(VisitForUpdateDTO visitToUpdate);
        void DeleteVisit(int id);
    }
}
