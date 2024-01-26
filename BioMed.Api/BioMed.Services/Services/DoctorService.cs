using AutoMapper;
using BioMed.Domain.DTOs.Doctor;
using BioMed.Domain.Entities;
using BioMed.Domain.Exceptions;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using BioMed.Infrastructure.Persistence;
using Microsoft.Extensions.Logging;

namespace BioMed.Services.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IMapper _mapper;
        private readonly BioMedDbContext _context;
        private readonly ILogger<DoctorService> _logger;

        public DoctorService(IMapper mapper,
            ILogger<DoctorService> logger,
            BioMedDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public PaginatedList<DoctorDTO> GetDoctors(
            DoctorResourceParameters doctorResourceParameters)
        {
            var query = _context.Doctors.AsQueryable();

            if(doctorResourceParameters.SpesializationId > 0) 
            {
                query = query.Where(d => d.SpesializationId 
                == doctorResourceParameters.SpesializationId);
            }
            if(doctorResourceParameters.PricePerVisit is not null)
            {
                query = query.Where(d => d.PricePerVisit 
                ==  doctorResourceParameters.PricePerVisit);
            }
            if(doctorResourceParameters.PricePerVisitGreaterThan is not null)
            {
                query = query.Where(d => d.PricePerVisit
                > doctorResourceParameters.PricePerVisitGreaterThan);
            }
            if(doctorResourceParameters.PricePerVisitLessThan is not null)
            {
                query = query.Where(d => d.PricePerVisit 
                < doctorResourceParameters.PricePerVisitLessThan);
            }

            if (!string.IsNullOrWhiteSpace(doctorResourceParameters.SearchString))
            {
                query = query.Where(d => d.FullName != null
                 && d.FullName.Contains(doctorResourceParameters.SearchString));
            }

            if (!string.IsNullOrWhiteSpace(doctorResourceParameters.OrderBy))
            {
                query = doctorResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "fullNmae" => query.OrderBy(d => d.FullName),
                    "fullNameDesc" => query.OrderByDescending(d => d.FullName),
                    "phoneNumber" => query.OrderBy(d => d.PhoneNumber),
                    "phoneNumberDesc" => query.OrderByDescending(d => d.PhoneNumber),
                    "email" => query.OrderBy(d => d.Email),
                    "emailDesc" => query.OrderByDescending(d => d.Email),
                    "pricePerVisit" => query.OrderBy(d => d.PricePerVisit),
                    "pricePerVisitDesc" => query.OrderByDescending(d => d.PricePerVisit),
                    _ => query.OrderBy(d => d.FullName),
                };
            }

            var doctors = query.ToPaginatedList(doctorResourceParameters.PageSize,
                doctorResourceParameters.PageNumber);
            var doctorDTOs = _mapper.Map<List<DoctorDTO>>(doctors);

            return new PaginatedList<DoctorDTO>(doctorDTOs,
                doctors.PageSize,
                doctors.TotalPages,
                doctors.CurrentPage);
        }

        public DoctorDTO? GetDoctorById(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);

            if (doctor is null)
            {
                throw new EntityNotFoundException($"Doctor with id: {id} not found");
            }

            return _mapper.Map<DoctorDTO>(doctor);
        }

        public DoctorDTO CreateDoctor(DoctorForCreateDTO doctorToCreate)
        {
            var doctorEntity = _mapper.Map<Doctor>(doctorToCreate);

            _context.Doctors.Add(doctorEntity);
            _context.SaveChanges();

            return _mapper.Map<DoctorDTO>(doctorEntity);
        }

        public void UpdateDoctor(DoctorForUpdateDTO doctorToUpdate)
        {
            var doctor = _mapper.Map<Doctor>(doctorToUpdate);

            _context.Doctors.Update(doctor);
            _context.SaveChanges();
        }

        public void DeleteDoctor(int id)
        {
            var doctor = _context.Doctors.FirstOrDefault(d => d.Id == id);

            if (doctor is null)
            {
                throw new EntityNotFoundException($"Doctor with id: {id} not found");
            }

            _context.Doctors.Remove(doctor);
            _context.SaveChanges();
        }
    }
}
