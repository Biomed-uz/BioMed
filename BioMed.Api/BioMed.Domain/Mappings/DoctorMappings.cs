using AutoMapper;
using BioMed.Domain.DTOs.Doctor;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class DoctorMappings : Profile
    {
        public DoctorMappings() 
        {
            CreateMap<Doctor, DoctorDTO>();
            CreateMap<DoctorDTO, Doctor>();
            CreateMap<DoctorForCreateDTO, Doctor>();
            CreateMap<DoctorForUpdateDTO, Doctor>();
        }
    }
}
