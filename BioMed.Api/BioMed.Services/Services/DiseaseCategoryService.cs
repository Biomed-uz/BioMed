using AutoMapper;
using BioMed.Domain.DTOs.DiseaseCategory;
using BioMed.Domain.Entities;
using BioMed.Domain.Exceptions;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using BioMed.Infrastructure.Persistence;

namespace BioMed.Services.Services
{
    public class DiseaseCategoryService : IDiseaseCategoryService
    {
        private readonly IMapper _mapper;
        private readonly BioMedDbContext _context;

        public DiseaseCategoryService(IMapper mapper,
            BioMedDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public PaginatedList<DiseaseCategoryDTO> GetDiseaseCategories(
            DiseaseCategoryResourceParameters diseaseCategoryResourceParameters)
        {
            var query = _context.DiseaseCategories.AsQueryable();

            if (!string.IsNullOrWhiteSpace(
                diseaseCategoryResourceParameters.SearchString))
            {
                query = query.Where(d => d.Name != null
                && d.Name.Contains(diseaseCategoryResourceParameters.SearchString));
            }

            if (!string.IsNullOrWhiteSpace(diseaseCategoryResourceParameters.OrderBy))
            {
                query = diseaseCategoryResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "name" => query.OrderBy(d => d.Name),
                    "nameDesc" => query.OrderByDescending(d => d.Name),
                    _ => query.OrderBy(d => d.Id)
                };
            }

            var diseaseCategories = query.ToPaginatedList(diseaseCategoryResourceParameters.PageSize,
                diseaseCategoryResourceParameters.PageNumber);

            var diseaseCategoryDTO = _mapper.Map<List<DiseaseCategoryDTO>>(diseaseCategories);

            return new PaginatedList<DiseaseCategoryDTO>(diseaseCategoryDTO,
                diseaseCategories.TotalCount,
                diseaseCategories.CurrentPage,
                diseaseCategories.PageSize);
        }

        public DiseaseCategoryDTO? GetDiseaseCategoryById(int id)
        {
            var diseaseCategory = _context.DiseaseCategories.FirstOrDefault(x => x.Id == id);

            if (diseaseCategory is null)
            {
                throw new EntityNotFoundException(
                    $"DiseaseCategory with id: {id} not found");
            }

            return _mapper.Map<DiseaseCategoryDTO>(diseaseCategory); ;
        }

        public DiseaseCategoryDTO CreateDiseaseCategory(
            DiseaseCategoryForCreateDTO diseaseCategoryToCreate)
        {
            var diseaseCategoryEntity = _mapper
                .Map<DiseaseCategory>(diseaseCategoryToCreate);

            _context.DiseaseCategories.Add(diseaseCategoryEntity);
            _context.SaveChanges();

            var diseaseCategoryDto = _mapper
                .Map<DiseaseCategoryDTO>(diseaseCategoryEntity);

            return diseaseCategoryDto;
        }

        public void UpdateDiseaseCategory(
            DiseaseCategoryForUpdateDTO diseaseCategoryToUpdate)
        {
            var diseaseCategoryEntity = _mapper
                .Map<DiseaseCategory>(diseaseCategoryToUpdate);

            _context.DiseaseCategories.Update(diseaseCategoryEntity);
            _context.SaveChanges();
        }

        public void DeleteDiseaseCategory(int id)
        {
            var diseaseCategory = _context.DiseaseCategories.FirstOrDefault(x => x.Id == id);

            if (diseaseCategory is null)
            {
                throw new EntityNotFoundException(
                    $"DiseaseCategory with id: {id} not found");
            }

            _context.DiseaseCategories.Remove(diseaseCategory);
            _context.SaveChanges();
        }
    }
}
