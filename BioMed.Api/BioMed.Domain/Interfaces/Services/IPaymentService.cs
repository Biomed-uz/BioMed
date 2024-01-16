using BioMed.Domain.DTOs.Payment;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface IPaymentService
    {
        PaginatedList<PaymentDTO> GetPayments(PaymentResourceParameters paymentResourceParameters);
        PaymentDTO? GetPaymentById(int id);
        PaymentDTO CreatePayment(PaymentForCreateDTO paymentToCreate);
        void UpdatePayment(PaymentForUpdateDTO paymentToUpdate);
        void DeletePayment(int id);
    }
}
