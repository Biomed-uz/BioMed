namespace BioMed.Domain.DTOs.Doctor
{
    public record DoctorForUpdateDTO(
        int Id,
        string FullName,
        string PhoneNumber,
        string Email,
        decimal PricePerVisit,
        int SpesializationId);
}
