using BioMed.Domain.DTOs.AnalysisType;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface IAnalysisTypeService
    {
        PaginatedList<AnalysisTypeDTO> GetAnalysisTypes(AnalysisTypeResourceParameters analysisTypeResourceParameters);
        AnalysisTypeDTO? GetvById(int id);
        AnalysisTypeDTO CreateAnalysisType(AnalysisTypeForCreateDTO analysisTypeToCreate);
        void UpdateAnalysisType(AnalysisTypeForUpdateDTO analysisTypeToUpdate);
        void DeleteAnalysisType(int id);
    }
}
