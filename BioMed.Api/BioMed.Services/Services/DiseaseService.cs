using AutoMapper;
using BioMed.Domain.DTOs.Disease;
using BioMed.Domain.Entities;
using BioMed.Domain.Exceptions;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using BioMed.Infrastructure.Persistence;

namespace BioMed.Services.Services
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IMapper _mapper;
        private readonly BioMedDbContext _context;

        public DiseaseService(IMapper mapper,
            BioMedDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public PaginatedList<DiseaseDTO> GetDiseases(
            DiseaseResourceParameters diseaseResourceParameters)
        {
            var query = _context.Diseases.AsQueryable();

            if(diseaseResourceParameters.DiseaseCategoryId > 0)
            {
                query = query.Where(d => d.DiseaseCategoryId 
                == diseaseResourceParameters.DiseaseCategoryId);
            }

            if (!string.IsNullOrWhiteSpace(diseaseResourceParameters.SearchString))
            {
                query = query.Where(d => d.Name != null
                && d.Name.Contains(diseaseResourceParameters.SearchString));
            }

            if(!string.IsNullOrWhiteSpace(diseaseResourceParameters.OrderBy))
            {
                query = diseaseResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "name" => query.OrderBy(d => d.Name),
                    "nameDesc" => query.OrderByDescending(d => d.Name),
                    "diseaseCategoryId" => query.OrderBy(d => d.DiseaseCategoryId),
                    "diseaseCategoryIdDesc" => query
                    .OrderByDescending(d => d.DiseaseCategoryId),
                    _ => query.OrderBy(d => d.Id)
                };
            }

            var diseases = query.ToPaginatedList(diseaseResourceParameters.PageSize,
                diseaseResourceParameters.PageNumber);

            var diseaseDtos = _mapper.Map<List<DiseaseDTO>>(diseases);

            return new PaginatedList<DiseaseDTO>(diseaseDtos,
                diseases.TotalCount,
                diseases.CurrentPage,
                diseases.PageSize);
        }

        public DiseaseDTO? GetDiseaseById(int id)
        {
            var disease = _context.Diseases.FirstOrDefault(d => d.Id == id);

            if(disease is null)
            {
                throw new EntityNotFoundException(
                    $"Disease with id : {id} not found");
            }

            return _mapper.Map<DiseaseDTO>(disease);
        }

        public DiseaseDTO CreateDisease(DiseaseForCreateDTO diseaseToCreate)
        {
            var diseaseEntity = _mapper.Map<Disease>(diseaseToCreate);

            _context.Diseases.Add(diseaseEntity);
            _context.SaveChanges();

            return _mapper.Map<DiseaseDTO>(diseaseEntity);
        }

        public void UpdateDisease(DiseaseForUpdateDTO diseaseToUpdate)
        {
            var diseaseEntity = _mapper.Map<Disease>(diseaseToUpdate);

            _context.Diseases.Update(diseaseEntity);
            _context.SaveChanges();
        }

        public void DeleteDisease(int id)
        {
            var disease = _context.Diseases.FirstOrDefault(e => e.Id == id);
            
            if(disease is null)
            {
                throw new EntityNotFoundException(
                    $"Disease with id {id} not found");
            }

            _context.Diseases.Remove(disease);
            _context.SaveChanges();
        }
    }
}
