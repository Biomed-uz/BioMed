using AutoMapper;
using BioMed.Domain.DTOs.Department;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class DepartmentMappings : Profile
    {
        public DepartmentMappings() 
        {
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO, Department>();
            CreateMap<DepartmentForCreateDTO, Department>();
            CreateMap<DepartmentForUpdateDTO, Department>();
        }
    }
}
