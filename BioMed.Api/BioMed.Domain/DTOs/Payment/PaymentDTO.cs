namespace BioMed.Domain.DTOs.Payment
{
    public record PaymentDTO(
        int Id,
        decimal Amount,
        DateTime Date,
        int VisitId);
}
