namespace BioMed.Domain.DTOs.Patient
{
    public record PatientForCreateDTO(
        string FirstName,
         string LastName,
         string MiddleName,
         string PhoneNumber,
         string Email,
         DateTime RegistrationDate,
         string Gender);
}
