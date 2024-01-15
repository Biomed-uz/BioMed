using BioMed.Domain.DTOs.LaboratoryResult;

namespace BioMed.Domain.DTOs.AnalysisType
{
    public record AnalysisTypeDTO(
        int Id,
        string Name,
        ICollection<LaboratoryResultDTO> LabResults);
}
