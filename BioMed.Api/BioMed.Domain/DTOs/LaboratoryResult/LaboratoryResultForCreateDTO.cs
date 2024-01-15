namespace BioMed.Domain.DTOs.LaboratoryResult
{
    public record LaboratoryResultForCreateDTO(
        string Result,
        DateTime Date,
        int TestTypeId);
}
