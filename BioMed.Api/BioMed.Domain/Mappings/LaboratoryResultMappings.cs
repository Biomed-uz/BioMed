using AutoMapper;
using BioMed.Domain.DTOs.LabResult;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class LabResultMappings : Profile
    {
        public LabResultMappings() 
        {
            CreateMap<LabResult, LabResultDTO>();
            CreateMap<LabResultDTO, LabResult>();
            CreateMap<LabResultForCreateDTO, LabResult>();
            CreateMap<LabResultForUpdateDTO, LabResult>();
        }
    }
}
