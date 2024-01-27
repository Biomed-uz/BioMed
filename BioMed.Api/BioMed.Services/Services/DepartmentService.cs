using AutoMapper;
using BioMed.Domain.DTOs.Department;
using BioMed.Domain.Entities;
using BioMed.Domain.Exceptions;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using BioMed.Infrastructure.Persistence;

namespace BioMed.Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly BioMedDbContext _context;

        public DepartmentService(IMapper mapper,
            BioMedDbContext dbContext)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public PaginatedList<DepartmentDTO> GetDepartments(
            DepartmentResourceParameters departmentResourceParameters)
        {
            var query = _context.Departments.AsQueryable();

            if (!string.IsNullOrWhiteSpace(departmentResourceParameters.SearchString))
            {
                query = query.Where(x => x.Name != null
                && x.Name.Contains(departmentResourceParameters.SearchString));
            }

            if (!string.IsNullOrEmpty(departmentResourceParameters.OrderBy))
            {
                query = departmentResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "name" => query.OrderBy(x => x.Name),
                    "namedesc" => query.OrderByDescending(x => x.Name),
                    _ => query.OrderBy(x => x.Name),
                };
            }
            var departments = query.ToPaginatedList(departmentResourceParameters.PageSize,
                departmentResourceParameters.PageNumber);

            var departmentDtos = _mapper.Map<List<DepartmentDTO>>(departments);

            return new PaginatedList<DepartmentDTO>(departmentDtos,
                departments.TotalCount,
                departments.CurrentPage,
                departments.PageSize);
        }

        public DepartmentDTO? GetDepartmentById(int id)
        {
            var department = _context.Departments.FirstOrDefault(x => x.Id == id);

            if (department == null)
            {
                throw new EntityNotFoundException($"Department with id {id} not found");
            }

            return _mapper.Map<DepartmentDTO>(department);
        }

        public DepartmentDTO CreateDepartment(DepartmentForCreateDTO departmentToCreate)
        {
            var departmentEntity = _mapper.Map<Department>(departmentToCreate);

            _context.Departments.Add(departmentEntity);
            _context.SaveChanges();

            return _mapper.Map<DepartmentDTO>(departmentEntity);
        }

        public void UpdateDepartment(DepartmentForUpdateDTO departmentToUpdate)
        {
            var departmentEntity = _mapper.Map<Department>(departmentToUpdate);

            _context.Departments.Update(departmentEntity);
            _context.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = _context.Departments.FirstOrDefault(d => d.Id == id);

            if (department is null)
            {
                throw new EntityNotFoundException($"Department with id: {id} not found");
            }

            _context.Departments.Remove(department);
            _context.SaveChanges();
        }
    }
}
