using BioMed.Domain.DTOs.LaboratoryResult;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/laboratoryResult")]
    [ApiController]
    [Authorize]
    public class LaboratoryResultController : Controller
    {
        private readonly ILaboratoryResultService _laboratoryResultService;

        public LaboratoryResultController(ILaboratoryResultService laboratoryResultService)
        {
            _laboratoryResultService = laboratoryResultService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LaboratoryResultDTO>> GetLaboratoryResult(
            [FromQuery] LaboratoryResultResourceParameters laboratoryResultResourceParameters)
        {
            var laboratoryResult = _laboratoryResultService.GetLaboratoryResults(laboratoryResultResourceParameters);
            
            var metaData = GetPagenationMetaData(laboratoryResult);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(laboratoryResult);
        }

        [HttpGet("{id}", Name = "GetLaboratoryResultById")]
        public ActionResult<LaboratoryResultDTO> Get(int id)
        {
            var laboratoryResult = _laboratoryResultService.GetLaboratoryResultById(id);

            return Ok(laboratoryResult);
        }

        [HttpPost]
        public ActionResult Post(LaboratoryResultForCreateDTO laboratoryResultForCreateDTO)
        {
            var laboratoryResult = _laboratoryResultService.CreateLaboratoryResult(laboratoryResultForCreateDTO);

            return CreatedAtAction(nameof(Get), new { id = laboratoryResult.Id }, laboratoryResult);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] LaboratoryResultForUpdateDTO laboratoryResultForUpdateDTO)
        {
            _laboratoryResultService.UpdateLaboratoryResult(laboratoryResultForUpdateDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _laboratoryResultService.DeleteLaboratoryResult(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<LaboratoryResultDTO> laboratoryResultDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = laboratoryResultDTOs.TotalCount,
                PageSize = laboratoryResultDTOs.PageSize,
                CurrentPage = laboratoryResultDTOs.CurrentPage,
                TotalPages = laboratoryResultDTOs.TotalPages,
            };
        }
    }
}
