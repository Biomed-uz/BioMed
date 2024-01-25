using BioMed.Domain.DTOs.Treatment;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/treatment")]
    [ApiController]
    [Authorize]
    public class TreatmentController : Controller
    {
        private readonly ITreatmentService _treatmentService;

        public TreatmentController(ITreatmentService treatmentService)
        {
            _treatmentService = treatmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TreatmentDTO>> GetTreatment(
            [FromQuery] TreatmentResourceParameters treatmentResourceParameters)
        {
            var treatmentDTOs = _treatmentService.GetTreatments(treatmentResourceParameters);

            var metadate = GetPagenationMetaData(treatmentDTOs);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadate));

            return Ok(treatmentDTOs);
        }

        [HttpGet("{id}", Name = "GetTreatmentById")]

        public ActionResult<TreatmentDTO> Get(int id)
        {
            var treatment = _treatmentService.GetTreatmentById(id);

            return Ok(treatment);
        }

        [HttpPost]
        public ActionResult<TreatmentDTO> Post(TreatmentForCreateDTO treatmentForCreateDTO)
        {
            var treatment = _treatmentService.CreateTreatment(treatmentForCreateDTO);

            return CreatedAtAction(nameof(Get), new { id = treatment.Id }, treatment);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] TreatmentForUpdateDTO treatmentForUpdateDTO)
        {
            _treatmentService.UpdateTreatment(treatmentForUpdateDTO);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            _treatmentService.DeleteTreatment(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<TreatmentDTO> treatmentDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = treatmentDTOs.TotalCount,
                PageSize = treatmentDTOs.PageSize,
                CurrentPage = treatmentDTOs.CurrentPage,
                TotalPages = treatmentDTOs.TotalPages,
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
