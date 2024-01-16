using BioMed.Domain.DTOs.Treatment;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface ITreatmentService
    {
        PaginatedList<TreatmentDTO> GetTreatments(TreatmentResourceParameters treatmentResourceParameters);
        TreatmentDTO? GetTreatmentById(int id);
        TreatmentDTO CreateTreatment(TreatmentForCreateDTO treatmentToCreate);
        void UpdateTreatment(TreatmentForUpdateDTO treatmentToUpdate);
        void DeleteTreatment(int id);
    }
}

