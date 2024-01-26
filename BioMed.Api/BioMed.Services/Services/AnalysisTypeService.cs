using AutoMapper;
using BioMed.Domain.DTOs.AnalysisType;
using BioMed.Domain.Entities;
using BioMed.Domain.Exceptions;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using BioMed.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace BioMed.Services.Services
{
    public class AnalysisTypeService : IAnalysisTypeService
    {
        private readonly IMapper _mapper;
        private readonly BioMedDbContext _context;
        private readonly ILogger<AnalysisTypeService> _logger;

        public AnalysisTypeService(IMapper mapper,
            ILogger<AnalysisTypeService> logger,
            BioMedDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public PaginatedList<AnalysisTypeDTO> GetAnalysisTypes(
            AnalysisTypeResourceParameters analysisTypeResourceParameters)
        {
            var query = _context.AnalysisTypes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(
                analysisTypeResourceParameters.SearchString))
            {
                query = query.Where(a => a.Name 
                == analysisTypeResourceParameters.SearchString);
            }

            if (!string.IsNullOrWhiteSpace(
                analysisTypeResourceParameters.OrderBy))
            {
                query = analysisTypeResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "name" => query.OrderBy(a => a.Name),
                    "nameDesc" => query.OrderByDescending(a => a.Name),
                    _ => query.OrderBy(a => a.Id)
                };
            }

            var analysisTypes = query.ToPaginatedList(
                analysisTypeResourceParameters.PageSize,
                analysisTypeResourceParameters.PageNumber);

            var analysisTypeDTOs = _mapper.Map<List<AnalysisTypeDTO>>(analysisTypes);

            return new PaginatedList<AnalysisTypeDTO>(analysisTypeDTOs,
                analysisTypes.TotalPages,
                analysisTypes.CurrentPage,
                analysisTypes.PageSize);
        }

        public AnalysisTypeDTO? GetvById(int id)
        {
            var analysisType = _context.AnalysisTypes
                .FirstOrDefault(x => x.Id == id);

            if(analysisType == null)
            {
                throw new EntityNotFoundException(
                    $"AnalysisType with id : {id} not found");
            }

            return _mapper.Map<AnalysisTypeDTO>( analysisType );
        }

        public AnalysisTypeDTO CreateAnalysisType(
            AnalysisTypeForCreateDTO analysisTypeToCreate)
        {
            var analysisTypeEntity = _mapper.Map<AnalysisType>(analysisTypeToCreate);

            _context.AnalysisTypes.Add(analysisTypeEntity);
            _context.SaveChanges();

            return _mapper.Map<AnalysisTypeDTO>(analysisTypeEntity);
        }

        public void UpdateAnalysisType(
            AnalysisTypeForUpdateDTO analysisTypeToUpdate)
        {
            var analysisTypeEntity = _mapper
                .Map<AnalysisType>(analysisTypeToUpdate);

            _context.AnalysisTypes.Update(analysisTypeEntity);
            _context.SaveChanges();
        }

        public void DeleteAnalysisType(int id)
        {
            var analysisType = _context.AnalysisTypes
                .FirstOrDefault(a => a.Id ==  id);

            if(analysisType == null)
            {
                throw new EntityNotFoundException(
                    $"AnalysisType with id : {id} not found");
            }

            _context.AnalysisTypes .Remove(analysisType);
            _context.SaveChanges();
        }
    }
}
