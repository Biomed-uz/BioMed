using BioMed.Domain.DTOs.Payment;
using BioMed.Domain.DTOs.Treatment;

namespace BioMed.Domain.DTOs.Visit
{
    public record VisitDTO(
         int Id,
         DateTime VisitDate,
         string Prescription,
         decimal TotalPrice,
         int PatientId,
         int DoctorId,
         ICollection<TreatmentDTO>? Treatments,
         ICollection<PaymentDTO>? Payments);
}
