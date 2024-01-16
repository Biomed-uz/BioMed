using BioMed.Domain.DTOs.Department;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;

namespace BioMed.Domain.Interfaces.Services
{
    public interface IDepartmentService
    {
        PaginatedList<DepartmentDTO> GetDepartments(DepartmentResourceParameters departmentResourceParameters);
        DepartmentDTO? GetDepartmentById(int id);
        DepartmentDTO CreateDepartment(DepartmentForCreateDTO departmentToCreate);
        void UpdateDepartment(DepartmentForUpdateDTO departmentToUpdate);
        void DeleteDepartment(int id);
    }
}
