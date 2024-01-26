using AutoMapper;
using BioMed.Domain.DTOs.Spesialization;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Exceptions;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using BioMed.Infrastructure.Persistence;
using BioMed.Domain.Entities;
using Microsoft.Extensions.Logging;

namespace BioMed.Services.Services
{
    public class SpesializationService : ISpesializationService
    {
        private readonly IMapper _mapper;
        private readonly BioMedDbContext _context;
        private readonly ILogger<SpesializationService> _logger;

        public SpesializationService(IMapper mapper,
            ILogger<SpesializationService> logger,
            BioMedDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public PaginatedList<SpesializationDTO> GetSpesializations(
            SpesializationResourceParameters spesializationResourceParameters)
        {
            var query = _context.Spesializations.AsQueryable();

            if (!string.IsNullOrWhiteSpace(spesializationResourceParameters.SearchString))
            {
                query = query.Where(x => x.Name != null
                    && x.Name.Contains(spesializationResourceParameters.SearchString));
            }

            if (spesializationResourceParameters.DepartmentId > 0)
            {
                query = query.Where(x => x.DepartmentId == spesializationResourceParameters.DepartmentId);
            }

            if (!string.IsNullOrEmpty(spesializationResourceParameters.OrderBy))
            {
                query = spesializationResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "name" => query.OrderBy(x => x.Name),
                    "namedesc" => query.OrderByDescending(x => x.Name),
                    "departmentId" => query.OrderBy(x => x.DepartmentId),
                    "departmentIddesc" => query.OrderByDescending(x => x.DepartmentId),
                    _ => query.OrderBy(x => x.Name),
                };
            }
            var spesializations = query.ToPaginatedList(spesializationResourceParameters.PageSize,
                spesializationResourceParameters.PageNumber);

            var spesializationDtos = _mapper.Map<List<SpesializationDTO>>(spesializations);

            return new PaginatedList<SpesializationDTO>(spesializationDtos,
                spesializations.TotalCount,
                spesializations.CurrentPage,
                spesializations.PageSize);
        }

        public SpesializationDTO? GetSpesializationById(int id)
        {
            var spesialization = _context.Spesializations.FirstOrDefault(x => x.Id == id);

            if(spesialization is null)
            {
                throw new EntityNotFoundException($"Spesialization with id: {id} not found");
            }

            return _mapper.Map<SpesializationDTO>(spesialization); ;
        }

        public SpesializationDTO CreateSpesialization(SpesializationForCreateDTO spesializationToCreate)
        {
            var spesializationEntity = _mapper.Map<Spesialization>(spesializationToCreate);

            _context.Spesializations.Add(spesializationEntity);
            _context.SaveChanges();

            var spesializationDto = _mapper.Map<SpesializationDTO>(spesializationEntity);

            return spesializationDto;
        }

        public void UpdateSpesialization(SpesializationForUpdateDTO spesializationToUpdate)
        {
            var spesializationEntity = _mapper.Map<Spesialization>(spesializationToUpdate);

            _context.Spesializations.Update(spesializationEntity);
            _context.SaveChanges();
        }

        public void DeleteSpesialization(int id)
        {
            var spesialization = _context.Spesializations.FirstOrDefault(x => x.Id == id);

            if (spesialization is null)
            {
                throw new EntityNotFoundException($"Spesialization with id: {id} not found");
            }

             _context.Spesializations.Remove(spesialization);
             _context.SaveChanges();
        }
    }
}
