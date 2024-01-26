using BioMed.Domain.DTOs.AnalysisType;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/analysisType")]
    [ApiController]
    [Authorize]
    public class AnalysisTypeController : Controller
    {
        private readonly IAnalysisTypeService _analysisTypeService;
        public AnalysisTypeController(IAnalysisTypeService analysisTypeService)
        {
            _analysisTypeService = analysisTypeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<AnalysisTypeDTO>> GetAnalysisType(
            [FromQuery] AnalysisTypeResourceParameters analysisTypeResourceParameters)
        {
            var analysisType = _analysisTypeService.GetAnalysisTypes(analysisTypeResourceParameters);

            var metaData = GetPagenationMetaData(analysisType);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(analysisType);
        }

        [HttpGet("{id}", Name = "GetAnalysisTypeById")]
        public ActionResult<AnalysisTypeDTO> Get(int id)
        {
            var analysisType = _analysisTypeService.GetvById(id);

            return Ok(analysisType);
        }

        [HttpPost]
        public ActionResult Post(AnalysisTypeForCreateDTO analysisTypeForCreateDTO)
        {
            var analysisType =  _analysisTypeService.CreateAnalysisType(analysisTypeForCreateDTO);

            return CreatedAtAction(nameof(Get), new { id = analysisType.Id }, analysisType);
        }

        [HttpPut]
        public ActionResult Put(int id,
            [FromBody] AnalysisTypeForUpdateDTO analysisTypeForUpdateDTO)
        {
            _analysisTypeService.UpdateAnalysisType(analysisTypeForUpdateDTO);

            return NoContent();
        }
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _analysisTypeService.DeleteAnalysisType(id);

            return NoContent();
        }


        private PagenationMetaData GetPagenationMetaData(PaginatedList<AnalysisTypeDTO> analysisTypeDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = analysisTypeDTOs.TotalCount,
                PageSize = analysisTypeDTOs.PageSize,
                CurrentPage = analysisTypeDTOs.CurrentPage,
                TotalPages = analysisTypeDTOs.TotalPages,
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
