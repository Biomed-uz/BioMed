namespace BioMed.Domain.DTOs.Payment
{
    public record PaymentForCreateDTO(
        decimal Amount,
        DateTime Date,
        int VisitId);
}
