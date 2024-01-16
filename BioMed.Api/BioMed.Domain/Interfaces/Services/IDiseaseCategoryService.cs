using BioMed.Domain.DTOs.DiseaseCategory;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface IDiseaseCategoryService
    {
        PaginatedList<DiseaseCategoryDTO> GetCategories(DiseaseCategoryResourceParameters diseaseCategoryResourceParameters);
        DiseaseCategoryDTO? GetDiseaseCategoryById(int id);
        DiseaseCategoryDTO CreateDiseaseCategory(DiseaseCategoryForCreateDTO diseaseCategoryToCreate);
        void UpdateDiseaseCategory(DiseaseCategoryForUpdateDTO diseaseCategoryToUpdate);
        void DeleteDiseaseCategory(int id);
    }
}
