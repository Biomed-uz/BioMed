namespace BioMed.Domain.DTOs.Disease
{
    public record DiseaseForCreateDTO(
        string Name,
        int DiseaseCategoryId);
}
