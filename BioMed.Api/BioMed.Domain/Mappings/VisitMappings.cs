using AutoMapper;
using BioMed.Domain.DTOs.Visit;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class VisitMappings : Profile
    {
        public VisitMappings() 
        {
            CreateMap<Visit, VisitDTO>();
            CreateMap<VisitDTO, Visit>();
            CreateMap<VisitForCreateDTO, Visit>();
            CreateMap<VisitForUpdateDTO, Visit>();
        }
    }
}
