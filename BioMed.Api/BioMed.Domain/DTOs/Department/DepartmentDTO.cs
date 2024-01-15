using BioMed.Domain.DTOs.Spesialization;

namespace BioMed.Domain.DTOs.Department
{
    public record DepartmentDTO(
        int Id,
        string Name,
        ICollection<SpesializationDTO> Spesializations);
}
