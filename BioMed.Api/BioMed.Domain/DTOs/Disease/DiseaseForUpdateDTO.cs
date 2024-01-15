namespace BioMed.Domain.DTOs.Disease
{
    public record DiseaseForUpdateDTO(
        int Id,
        string Name,
        int DiseaseCategoryId);
}
