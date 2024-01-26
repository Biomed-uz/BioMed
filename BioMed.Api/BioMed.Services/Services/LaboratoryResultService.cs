using AutoMapper;
using BioMed.Domain.DTOs.LaboratoryResult;
using BioMed.Domain.Entities;
using BioMed.Domain.Exceptions;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using BioMed.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace BioMed.Services.Services
{
    public class LaboratoryResultService : ILaboratoryResultService
    {
        private readonly IMapper _mapper;
        private readonly BioMedDbContext _context;
        private readonly ILogger<LaboratoryResultService> _logger;

        public LaboratoryResultService(IMapper mapper,
            ILogger<LaboratoryResultService> logger,
            BioMedDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public PaginatedList<LaboratoryResultDTO> GetLaboratoryResults(
            LaboratoryResultResourceParameters laboratoryResultResourceParameters)
        {
            var query = _context.LaboratoryResults.AsQueryable();

            if(laboratoryResultResourceParameters.AnalysisTypeId >0)
            {
                query = query.Where(l => l.AnalysisTypeId 
                ==  laboratoryResultResourceParameters.AnalysisTypeId);
            }

            if(!string.IsNullOrWhiteSpace(
                laboratoryResultResourceParameters.SearchString))
            {
                query = query.Where(l => l.Result 
                ==  laboratoryResultResourceParameters.SearchString);
            }

            if (!string.IsNullOrWhiteSpace(
                laboratoryResultResourceParameters.OrderBy))
            {
                query = laboratoryResultResourceParameters
                    .OrderBy.ToLowerInvariant() switch
                {
                    "result" => query.OrderBy(l => l.Result),
                    "resultDesc" => query.OrderByDescending(l => l.Result),
                    "analysisTypeId" => query.OrderBy(l => l.AnalysisTypeId),
                    "analysisTypeIdDesc" => query
                    .OrderByDescending(l => l.AnalysisTypeId),
                    "date" => query.OrderBy(l => l.Date),
                    "dateDesc" => query.OrderByDescending(l => l.Date),
                    _ => query.OrderBy(l => l.Id)
                };
            }

            var labResults = query.ToPaginatedList(
                laboratoryResultResourceParameters.PageSize
                , laboratoryResultResourceParameters.PageNumber);

            var labResultDTO = _mapper.Map<List<LaboratoryResultDTO>>(labResults);

            return new PaginatedList<LaboratoryResultDTO>(labResultDTO,
                labResults.TotalCount,
                labResults.CurrentPage,
                labResults.PageSize);
        }

        public LaboratoryResultDTO? GetLaboratoryResultById(int id)
        {
            var labresults = _context.LaboratoryResults
                .FirstOrDefault(x => x.Id == id);

            if (labresults == null)
            {
                throw new EntityNotFoundException(
                    $"LaboratoryResult with id : {id} not found");
            }

            return _mapper.Map<LaboratoryResultDTO>( labresults );
        }

        public LaboratoryResultDTO CreateLaboratoryResult(
            LaboratoryResultForCreateDTO laboratoryResultToCreate)
        {
            var labResultEntity = _mapper
                .Map<LaboratoryResult>(laboratoryResultToCreate);

            _context.LaboratoryResults.Add(labResultEntity);
            _context.SaveChanges();

            return _mapper.Map<LaboratoryResultDTO>(labResultEntity);
        }

        public void UpdateLaboratoryResult(
            LaboratoryResultForUpdateDTO laboratoryResultToUpdate)
        {
            var labResultEntity = _mapper
                .Map<LaboratoryResult>(laboratoryResultToUpdate);

            _context.LaboratoryResults.Update(labResultEntity);
            _context.SaveChanges();
        }

        public void DeleteLaboratoryResult(int id)
        {
            var labResult = _context.LaboratoryResults
                .FirstOrDefault(x => x.Id == id);

            if(labResult is null)
            {
                throw new EntityNotFoundException(
                    $"LaboratoryResult with id : {id} not found");
            }

            _context.LaboratoryResults.Remove(labResult);
            _context.SaveChanges();
        }
    }
}
