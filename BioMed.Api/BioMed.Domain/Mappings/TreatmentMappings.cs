using AutoMapper;
using BioMed.Domain.DTOs.Treatment;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class TreatmentMappings : Profile
    {
        public TreatmentMappings() 
        {
            CreateMap<Treatment, TreatmentDTO>();
            CreateMap<TreatmentDTO, Treatment>();
            CreateMap<TreatmentForCreateDTO, Treatment>();
            CreateMap<TreatmentForUpdateDTO, Treatment>();
        }
    }
}
