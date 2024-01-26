using BioMed.Domain.DTOs.DiseaseCategory;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/diseaseCategory")]
    [ApiController]
    [Authorize]
    public class DiseaseCategoryController : Controller
    {
        private readonly IDiseaseCategoryService _diseaseCategoryService;

        public DiseaseCategoryController(IDiseaseCategoryService diseaseCategoryService)
        {
            _diseaseCategoryService = diseaseCategoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DiseaseCategoryDTO>> GetDiseaseCategory(
            [FromQuery] DiseaseCategoryResourceParameters diseaseCategoryResourceParameters)
        {
            var diseaseCategory = _diseaseCategoryService.GetDiseaseCategories(diseaseCategoryResourceParameters);

            var metaData = GetPagenationMetaData(diseaseCategory);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

            return Ok(diseaseCategory);
        }

        [HttpGet("{id}", Name = "GetDiseaseCategoryById")]
        public ActionResult<DiseaseCategoryDTO> Get(int id)
        {
            var diseaseCategory = _diseaseCategoryService.GetDiseaseCategoryById(id);

            return Ok(diseaseCategory);
        }

        [HttpPost]
        public ActionResult Post(DiseaseCategoryForCreateDTO diseaseCategoryForCreateDTO)
        {
            var diseaseCategory = _diseaseCategoryService.CreateDiseaseCategory(diseaseCategoryForCreateDTO);

            return CreatedAtAction(nameof(Get), new { id = diseaseCategory.Id }, diseaseCategory);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] DiseaseCategoryForUpdateDTO diseaseCategoryForUpdateDTO)
        {
            _diseaseCategoryService.UpdateDiseaseCategory(diseaseCategoryForUpdateDTO);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _diseaseCategoryService.DeleteDiseaseCategory(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<DiseaseCategoryDTO> diseaseCategoryDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = diseaseCategoryDTOs.TotalCount,
                PageSize = diseaseCategoryDTOs.PageSize,
                CurrentPage = diseaseCategoryDTOs.CurrentPage,
                TotalPages = diseaseCategoryDTOs.TotalPages,
            };
        }
    }
}
