namespace BioMed.Domain.DTOs.Visit
{
    public record VisitForUpdateDTO(
        int Id,
        DateTime VisitDate,
        string Prescription,
        decimal TotalPrice,
        int PatientId,
        int DoctorId);
}
