using AutoMapper;
using BioMed.Domain.DTOs.Payment;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class PaymentMappings : Profile
    {
        public PaymentMappings() 
        {
            CreateMap<Payment, PaymentDTO>();
            CreateMap<PaymentDTO, Payment>();
            CreateMap<PaymentForCreateDTO, Payment>();
            CreateMap<PaymentForUpdateDTO, Payment>();
        }
    }
}
