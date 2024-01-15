using BioMed.Domain.DTOs.Doctor;

namespace BioMed.Domain.DTOs.Spesialization
{
    public record SpesializationDTO(
        int Id,
        string Name,
        int DepartmentId,
        ICollection<DoctorDTO> Doctors);
}
