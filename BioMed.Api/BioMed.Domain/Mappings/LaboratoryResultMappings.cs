using AutoMapper;
using BioMed.Domain.DTOs.LaboratoryResult;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class LaboratoryResultMappings : Profile
    {
        public LaboratoryResultMappings() 
        {
            CreateMap<LaboratoryResult, LaboratoryResultDTO>();
            CreateMap<LaboratoryResultDTO, LaboratoryResult>();
            CreateMap<LaboratoryResultForCreateDTO, LaboratoryResult>();
            CreateMap<LaboratoryResultForUpdateDTO, LaboratoryResult>();
        }
    }
}
