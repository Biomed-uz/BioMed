using BioMed.Domain.DTOs.Disease;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/disease")]
    [ApiController]
    [Authorize]
    public class DiseaseController : Controller
    {
        private readonly IDiseaseService _diseaseService;

        public DiseaseController(IDiseaseService diseaseService)
        {
            _diseaseService = diseaseService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DiseaseDTO>> GetDisease(
            [FromQuery] DiseaseResourceParameters diseaseResourceParameters)
        {
            var disease = _diseaseService.GetDiseases(diseaseResourceParameters);

            var metadate = GetPagenationMetaData(disease);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadate));

            return Ok(disease);
        }

        [HttpGet("{id}", Name = "GetDiseaseById")]
        public ActionResult<DiseaseDTO> Get(int id)
        {
            var disease = _diseaseService.GetDiseaseById(id);

            return Ok(disease);
        }

        [HttpPost]
        public ActionResult Post(DiseaseForCreateDTO diseaseForCreateDTO)
        {
            var disease = _diseaseService.CreateDisease(diseaseForCreateDTO);

            return CreatedAtAction(nameof(Get), new { id = disease.Id }, disease);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] DiseaseForUpdateDTO diseaseForUpdateDTO)
        {
            _diseaseService.UpdateDisease(diseaseForUpdateDTO);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _diseaseService.DeleteDisease(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<DiseaseDTO> diseaseDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = diseaseDTOs.TotalCount,
                PageSize = diseaseDTOs.PageSize,
                CurrentPage = diseaseDTOs.CurrentPage,
                TotalPages = diseaseDTOs.TotalPages,
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
