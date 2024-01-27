using AutoMapper;
using BioMed.Domain.DTOs.Treatment;
using BioMed.Domain.Entities;
using BioMed.Domain.Exceptions;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using BioMed.Infrastructure.Persistence;

namespace BioMed.Services.Services
{
    public class TreatmentService : ITreatmentService
    {
        private readonly IMapper _mapper;
        private readonly BioMedDbContext _context;

        public TreatmentService(IMapper mapper,
            BioMedDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public PaginatedList<TreatmentDTO> GetTreatments(
            TreatmentResourceParameters treatmentResourceParameters)
        {
            var query = _context.Treatments.AsQueryable();

            if(treatmentResourceParameters.DiseaseId > 0)
            {
                query = query.Where(t => t.DiseaseId
                == treatmentResourceParameters.DiseaseId);
            }
            if (treatmentResourceParameters.VisitId > 0)
            {
                query = query.Where(t => t.VisitId
                == treatmentResourceParameters.VisitId);
            }
            if (treatmentResourceParameters.LaboratoryResultId > 0)
            {
                query = query.Where(t => t.LaboratoryResultId
                == treatmentResourceParameters.LaboratoryResultId);
            }

            if (!string.IsNullOrWhiteSpace(treatmentResourceParameters.OrderBy))
            {
                query = treatmentResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "diseaseId" => query.OrderBy(x => x.DiseaseId),
                    "diseaseIdDesc" => query.OrderByDescending(x => x.DiseaseId),
                    "labresultId" => query.OrderBy(x => x.LaboratoryResultId),
                    "labresultIdDesc" => query.OrderByDescending(x => x.LaboratoryResultId),
                    "visitId" => query.OrderBy(x => x.VisitId),
                    "visitIdDesc" => query.OrderByDescending(x => x.VisitId),
                    _ => query.OrderBy(x => x.Id)
                };
            }

            var treatments = query.ToPaginatedList(treatmentResourceParameters.PageSize,
                treatmentResourceParameters.PageNumber);
            var treatmentsDTOs = _mapper.Map<List<TreatmentDTO>>(treatments);

            return new PaginatedList<TreatmentDTO>(treatmentsDTOs,
                treatments.TotalPages,
                treatments.CurrentPage,
                treatments.PageSize);
        }

        public TreatmentDTO? GetTreatmentById(int id)
        {
            var treatment = _context.Treatments.FirstOrDefault(x => x.Id == id);
            if (treatment is null)
            {
                throw new EntityNotFoundException(
                    $"Treatment with id : {id} not found.");
            }

            return _mapper.Map<TreatmentDTO>(treatment);
        }

        public TreatmentDTO CreateTreatment(TreatmentForCreateDTO treatmentToCreate)
        {
            var treatmentEntity = _mapper.Map<Treatment>(treatmentToCreate);

            _context.Treatments.Add(treatmentEntity);
            _context.SaveChanges();

            return _mapper.Map<TreatmentDTO>(treatmentEntity);
        }

        public void UpdateTreatment(TreatmentForUpdateDTO treatmentToUpdate)
        {
            var treatmententity = _mapper.Map<Treatment>(treatmentToUpdate);

            _context.Treatments.Update(treatmententity);
            _context.SaveChanges();
        }

        public void DeleteTreatment(int id)
        {
            var treatment = _context.Treatments.FirstOrDefault(x => x.Id == id);

            if (treatment is null)
            {
                throw new EntityNotFoundException(
                    $"Treatment with id : {id} not found");
            }

            _context.Treatments.Remove(treatment);
            _context.SaveChanges();
        }
    }
}
