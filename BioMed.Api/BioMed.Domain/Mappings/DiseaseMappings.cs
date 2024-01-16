using AutoMapper;
using BioMed.Domain.DTOs.Disease;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class DiseaseMappings : Profile
    {
        public DiseaseMappings() 
        {
            CreateMap<Disease, DiseaseDTO>();
            CreateMap<DiseaseDTO, Disease>();
            CreateMap<DiseaseForCreateDTO, Disease>();
            CreateMap<DiseaseForUpdateDTO, Disease>();
        }
    }
}
