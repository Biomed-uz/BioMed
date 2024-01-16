using AutoMapper;
using BioMed.Domain.DTOs.TestType;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class TestTypeMappings : Profile
    {
        public TestTypeMappings() 
        {
            CreateMap<TestType, TestTypeDTO>();
            CreateMap<TestTypeDTO, TestType>();
            CreateMap<TestTypeForCreateDTO, TestType>();
            CreateMap<TestTypeForUpdateDTO, TestType>();
        }
    }
}
