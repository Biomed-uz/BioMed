namespace BioMed.Domain.DTOs.Treatment
{
    public record TreatmentDTO(
        int Id,
        string Prescription,
        int VisitId,
        int LabResultId,
        int DiseaseId);
}
