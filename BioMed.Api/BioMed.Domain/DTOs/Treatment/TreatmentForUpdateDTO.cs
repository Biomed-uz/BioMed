namespace BioMed.Domain.DTOs.Treatment
{
    public record TreatmentForUpdateDTO(
        int Id,
        string Prescription,
        int VisitId,
        int LabResultId,
        int DiseaseId);
}
