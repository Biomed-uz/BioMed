using BioMed.Domain.DTOs.Department;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/department")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DepartmentDTO>> GetDepartment(
            [FromQuery] DepartmentResourceParameters departmentResourceParameters)
        {
            var department = _departmentService.GetDepartments(departmentResourceParameters);

            var metaData = GetPagenationMetaData(department);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(department);
        }

        [HttpGet("{id}", Name = "GetDepartmentById")]
        public ActionResult<DepartmentDTO> Get(int id)
        {
            var department = _departmentService.GetDepartmentById(id);

            return Ok(department);
        }

        [HttpPost]
        public ActionResult Post(DepartmentForCreateDTO departmentForCreateDTO)
        {
            var department =  _departmentService.CreateDepartment(departmentForCreateDTO);

            return CreatedAtAction(nameof(Get), new { id = department.Id }, department);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] DepartmentForUpdateDTO departmentForUpdateDTO)
        {
            _departmentService.UpdateDepartment(departmentForUpdateDTO);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _departmentService.DeleteDepartment(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<DepartmentDTO> departmentDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = departmentDTOs.TotalCount,
                PageSize = departmentDTOs.PageSize,
                CurrentPage = departmentDTOs.CurrentPage,
                TotalPages = departmentDTOs.TotalPages,
            };
        }

        class PagenationMetaData
        {
            public int Totalcount { get; set; }
            public int PageSize { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }
    }
}
