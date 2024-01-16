using AutoMapper;
using BioMed.Domain.DTOs.Spesialization;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class SpesializationMappings : Profile
    {
        public SpesializationMappings() 
        {
            CreateMap<Spesialization, SpesializationDTO>();
            CreateMap<SpesializationDTO, Spesialization>();
            CreateMap<SpesializationForCreateDTO, Spesialization>();
            CreateMap<SpesializationForUpdateDTO, Spesialization>();
        }
    }
}
