namespace BioMed.Domain.DTOs.Visit
{
    public record VisitForCreateDTO(
        DateTime VisitDate,
         string Prescription,
         decimal TotalPrice,
         int PatientId,
         int DoctorId);    
}
