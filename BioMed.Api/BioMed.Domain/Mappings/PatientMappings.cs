using AutoMapper;
using BioMed.Domain.DTOs.Patient;
using BioMed.Domain.Entities;

namespace BioMed.Domain.Mappings
{
    internal class PatientMappings : Profile
    {
        public PatientMappings() 
        {
            CreateMap<Patient, PatientDTO>();
            CreateMap<PatientDTO, Patient>();
            CreateMap<PatientForCreateDTO, Patient>();
            CreateMap<PatientForUpdateDTO, Patient>();
        }
    }
}
