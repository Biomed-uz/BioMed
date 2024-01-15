namespace BioMed.Domain.DTOs.LaboratoryResult
{
    public record LaboratoryResultForUpdateDTO(
        int Id,
        string Result,
        DateTime Date,
        int TestTypeId);
}
