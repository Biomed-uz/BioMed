using BioMed.Domain.DTOs.Visit;

namespace BioMed.Domain.DTOs.Doctor
{
    public record DoctorDTO(
        int Id,
        int SpesializationId,
        string FullName,
        string PhoneNumber,
        string Email,
        decimal PricePerVisit,
        ICollection<VisitDTO>? Visits);
}
