using BioMed.Domain.DTOs.Visit;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/visit")]
    [ApiController]
    [Authorize]
    public class VisitController : Controller
    {
        private readonly IVisitService _visitService;
        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<VisitDTO>> GetVisit(
            [FromQuery] VisitResourceParameters visitResourceParameters)
        {
            var visit = _visitService.GetVisits(visitResourceParameters);

            var metadate = GetPagenationMetaData(visit);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadate));

            return Ok(visit);
        }

        [HttpGet("{id}", Name = "GetVisitById")]
        public ActionResult<VisitDTO> Get(int id)
        {
            var visit = _visitService.GetVisitById(id);

            return Ok(visit);
        }

        [HttpPost]
        public ActionResult<VisitDTO> Post(VisitForCreateDTO visitDTO)
        {
            var visit = _visitService.CreateVisit(visitDTO);

            return CreatedAtAction(nameof(Get), new { id = visit.Id }, visit);
        }

        [HttpPut]
        public ActionResult<VisitDTO> Put(VisitForUpdateDTO visitDTO)
        {
            _visitService.UpdateVisit(visitDTO);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult<VisitDTO> Delete(int id)
        {
            _visitService.DeleteVisit(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<VisitDTO> visitDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = visitDTOs.TotalCount,
                PageSize = visitDTOs.PageSize,
                CurrentPage = visitDTOs.CurrentPage,
                TotalPages = visitDTOs.TotalPages,
            };
        }
    }
}
