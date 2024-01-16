using AutoMapper;
using BioMed.Domain.DTOs.DiseaseCategory;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class DiseaseCategoryMappings : Profile
    {
        public DiseaseCategoryMappings() 
        {
            CreateMap<DiseaseCategory, DiseaseCategoryDTO>();
            CreateMap<DiseaseCategoryDTO, DiseaseCategory>();
            CreateMap<DiseaseCategoryForCreateDTO, DiseaseCategory>();
            CreateMap<DiseaseCategoryForUpdateDTO, DiseaseCategory>();
        }
    }
}
