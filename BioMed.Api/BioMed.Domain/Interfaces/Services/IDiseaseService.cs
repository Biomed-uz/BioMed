using BioMed.Domain.DTOs.Disease;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface IDiseaseService
    {
        PaginatedList<DiseaseDTO> GetDiseases(DiseaseResourceParameters diseaseResourceParameters);
        DiseaseDTO? GetDiseaseById(int id);
        DiseaseDTO CreateDisease(DiseaseForCreateDTO diseaseToCreate);
        void UpdateDisease(DiseaseForUpdateDTO diseaseToUpdate);
        void DeleteDisease(int id);
    }
}
