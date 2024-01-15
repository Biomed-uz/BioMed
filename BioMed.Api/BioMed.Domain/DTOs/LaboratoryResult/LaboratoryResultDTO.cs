using BioMed.Domain.DTOs.Treatment;

namespace BioMed.Domain.DTOs.LaboratoryResult
{
    public record LaboratoryResultDTO(
        int Id,
        string Result,
        DateTime Date,
        int TestTypeId,
        ICollection<TreatmentDTO> Treatments);
}
