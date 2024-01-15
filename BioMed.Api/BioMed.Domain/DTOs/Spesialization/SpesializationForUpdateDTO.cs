namespace BioMed.Domain.DTOs.Spesialization
{
    public record SpesializationForUpdateDTO(
        int Id,
        string Name,
        int DepartmentId);
}
