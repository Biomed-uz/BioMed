using BioMed.Domain.DTOs.Disease;

namespace BioMed.Domain.DTOs.DiseaseCategory
{
    public record DiseaseCategoryDTO(
    int Id,
    string Name,
    ICollection<DiseaseDTO> Diseases);
}
