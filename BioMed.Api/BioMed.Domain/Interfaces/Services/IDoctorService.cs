using BioMed.Domain.DTOs.Doctor;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface IDoctorService
    {
        PaginatedList<DoctorDTO> GetDoctors(DoctorResourceParameters doctorResourceParameters);
        DoctorDTO? GetDoctorById(int id);
        DoctorDTO CreateDoctor(DoctorForCreateDTO doctorToCreate);
        void UpdateDoctor(DoctorForUpdateDTO doctorToUpdate);
        void DeleteDoctor(int id);
    }
}
