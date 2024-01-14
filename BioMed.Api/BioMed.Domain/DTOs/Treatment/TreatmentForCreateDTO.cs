namespace BioMed.Domain.DTOs.Treatment
{
    public record TreatmentForCreateDTO(
        string Prescription,
        int VisitId,
        int LabResultId,
        int DiseaseId);
}
