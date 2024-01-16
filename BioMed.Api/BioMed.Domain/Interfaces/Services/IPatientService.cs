using BioMed.Domain.DTOs.Patient;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface IPatientService
    {
        PaginatedList<PatientDTO> GetPatients(PatientResourceParameters patientResourceParameters);
        PatientDTO? GetPatientById(int id);
        PatientDTO CreatePatient(PatientForCreateDTO patientToCreate);
        void UpdatePatient(PatientForUpdateDTO patientToUpdate);
        void DeletePatient(int id);
    }
}
