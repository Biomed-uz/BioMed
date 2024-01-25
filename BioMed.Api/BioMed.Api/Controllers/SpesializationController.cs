using BioMed.Domain.DTOs.Spesialization;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/spesialization")]
    [ApiController]
    [Authorize]
    public class SpesializationController : Controller
    {
        private readonly ISpesializationService _spesializationService;

        public SpesializationController(ISpesializationService spesializationService)
        {
            _spesializationService = spesializationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SpesializationDTO>> GetSpesialization(
            [FromQuery] SpesializationResourceParameters spesializationResourceParameters)
        {
            var spesialization = _spesializationService.GetSpesializations(spesializationResourceParameters);

            var metadata = GetPagenationMetaData(spesialization);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(spesialization);
        }

        [HttpGet("{id}", Name = "GetSpesializationById")]
        public ActionResult<SpesializationDTO> Get(int id)
        {
            var spesialization = _spesializationService.GetSpesializationById(id);

            return Ok(spesialization);
        }

        [HttpPost]
        public ActionResult<SpesializationDTO> Post(SpesializationForCreateDTO spesializationForCreationDTO)
        {
            var spesialization = _spesializationService.CreateSpesialization(spesializationForCreationDTO);

            return CreatedAtAction(nameof(Get), new { id = spesialization.Id }, spesialization);
        }

        [HttpPut]
        public ActionResult<SpesializationDTO> Put(SpesializationForUpdateDTO spesializationForUpdateDTO)
        {
            _spesializationService.UpdateSpesialization(spesializationForUpdateDTO);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _spesializationService.DeleteSpesialization(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<SpesializationDTO> spesializationDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = spesializationDTOs.TotalCount,
                PageSize = spesializationDTOs.PageSize,
                CurrentPage = spesializationDTOs.CurrentPage,
                TotalPages = spesializationDTOs.TotalPages,
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
