using AutoMapper;
using BioMed.Domain.DTOs.AnalysisType;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class AnalysisTypeMappings : Profile
    {
        public AnalysisTypeMappings() 
        {
            CreateMap<AnalysisType, AnalysisTypeDTO>();
            CreateMap<AnalysisTypeDTO, AnalysisType>();
            CreateMap<AnalysisTypeForCreateDTO, AnalysisType>();
            CreateMap<AnalysisTypeForUpdateDTO, AnalysisType>();
        }
    }
}
