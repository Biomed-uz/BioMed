namespace BioMed.Domain.DTOs.Doctor
{
    public record DoctorForCreateDTO(
        string FullName,
        string PhoneNumber,
        string Email,
        decimal PricePerVisit,
        int SpesializationId);
}
