using BioMed.Domain.DTOs.Spesialization;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface ISpesializationService
    {
        PaginatedList<SpesializationDTO> GetSpesializations(SpesializationResourceParameters spesializationResourceParameters);
        SpesializationDTO? GetSpesializationById(int id);
        SpesializationDTO CreateSpesialization(SpesializationForCreateDTO spesializationToCreate);
        void UpdateSpesialization(SpesializationForUpdateDTO spesializationToUpdate);
        void DeleteSpesialization(int id);
    }
}
