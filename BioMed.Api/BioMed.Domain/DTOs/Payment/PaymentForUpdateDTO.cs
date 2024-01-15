namespace BioMed.Domain.DTOs.Payment
{
    public record PaymentForUpdateDTO(
        int Id,
        decimal Amount,
        DateTime Date,
        int VisitId);
}
