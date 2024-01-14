using BioMed.Domain.DTOs.Treatment;

namespace BioMed.Domain.DTOs.Disease
{
    public record DiseaseDTO(
        int Id,
        string Name,
        int DiseaseCategoryId,
        ICollection<TreatmentDTO> Treatments);
}
