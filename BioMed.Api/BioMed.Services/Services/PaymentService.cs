using AutoMapper;
using BioMed.Domain.DTOs.Payment;
using BioMed.Domain.Entities;
using BioMed.Domain.Exceptions;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using BioMed.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace BioMed.Services.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IMapper _mapper;
        private readonly BioMedDbContext _context;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IMapper mapper,
            ILogger<PaymentService> logger,
            BioMedDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public PaginatedList<PaymentDTO> GetPayments(
            PaymentResourceParameters paymentResourceParameters)
        {
            var query = _context.Payments.AsQueryable();

            if(paymentResourceParameters.VisitId > 0)
            {
                query = query.Where(p => p.VisitId 
                ==  paymentResourceParameters.VisitId);
            }
            if(paymentResourceParameters.Amount >= 0) 
            {
                query = query.Where(p => p.Amount 
                == paymentResourceParameters.Amount);
            }
            if(paymentResourceParameters.AmountGreaterThan >= 0)
            {
                query = query.Where(p => p.Amount 
                > paymentResourceParameters.AmountGreaterThan);
            }
            if(paymentResourceParameters.AmountLessThan >= 0)
            {
                query = query.Where(p => p.Amount 
                < paymentResourceParameters.AmountLessThan);
            }

            if (!string.IsNullOrWhiteSpace(paymentResourceParameters.OrderBy))
            {
                query = paymentResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "amount" => query.OrderBy(x => x.Amount),
                    "amountDesc" => query.OrderByDescending(x => x.Amount),
                    "Date" => query.OrderBy(x => x.Date),
                    "DateDesc" => query.OrderByDescending(x => x.Date),
                    "visitId" => query.OrderBy(x => x.VisitId),
                    "visitIdDesc" => query.OrderByDescending(x => x.VisitId),
                    _ => query.OrderBy(x => x.Date)
                };
            }

            var payments = query.ToPaginatedList(paymentResourceParameters.PageSize,
                paymentResourceParameters.PageNumber);
            var paymentsDTOs = _mapper.Map<List<PaymentDTO>>(payments);

            return new PaginatedList<PaymentDTO>(paymentsDTOs,
                payments.TotalPages,
                payments.CurrentPage,
                payments.PageSize);
        }

        public PaymentDTO? GetPaymentById(int id)
        {
            var payment = _context.Payments.FirstOrDefault(x => x.Id == id);

            if (payment is null)
            {
                throw new EntityNotFoundException(
                    $"Payment with id:{id} not found");
            }

            return _mapper.Map<PaymentDTO>(payment);
        }

        public PaymentDTO CreatePayment(PaymentForCreateDTO paymentToCreate)
        {
            var payment = _mapper.Map<Payment>(paymentToCreate);

            _context.Payments.Add(payment);
            _context.SaveChanges();

            return _mapper.Map<PaymentDTO>(payment);
        }

        public void UpdatePayment(PaymentForUpdateDTO paymentToUpdate)
        {
            var payment = _mapper.Map<Payment>(paymentToUpdate);

            _context.Payments.Update(payment);
            _context.SaveChanges();
        }

        public void DeletePayment(int id)
        {
            var payment = _context.Payments.FirstOrDefault(x => x.Id == id);

            if (payment is null)
            {
                throw new EntityNotFoundException(
                    $"Payment with id:{id} not found");
            }

            _context.Payments.Remove(payment);
            _context.SaveChanges();
        }
    }
}
