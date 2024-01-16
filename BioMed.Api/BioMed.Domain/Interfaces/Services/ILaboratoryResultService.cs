using BioMed.Domain.DTOs.LaboratoryResult;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface ILaboratoryResultService
    {
        PaginatedList<LaboratoryResultDTO> GetLaboratoryResults(LaboratoryResultResourceParameters laboratoryResultResourceParameters);
        LaboratoryResultDTO? GetLaboratoryResultById(int id);
        LaboratoryResultDTO CreateLaboratoryResult(LaboratoryResultForCreateDTO laboratoryResultToCreate);
        void UpdateLaboratoryResult(LaboratoryResultForUpdateDTO laboratoryResultToUpdate);
        void DeleteLaboratoryResult(int id);
    }
}
