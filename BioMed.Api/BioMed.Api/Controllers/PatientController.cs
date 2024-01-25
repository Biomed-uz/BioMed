using BioMed.Domain.DTOs.Patient;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/patient")]
    [ApiController]
    [Authorize]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PatientDTO>> GetPatient(
            [FromQuery] PatientResourceParameters patientResourceParameters)
        {
            var patient = _patientService.GetPatients(patientResourceParameters);

            var metadate = GetPagenationMetaData(patient);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadate));

            return Ok(patient);
        }

        [HttpGet("{id}", Name = "GetPatientById")]
        public ActionResult<PatientDTO> Get(int id)
        {
            var patient = _patientService.GetPatientById(id);

            return Ok(patient);
        }

        [HttpPost]
        public ActionResult Post(PatientForCreateDTO patientForCreateDTO)
        {
            var patient = _patientService.CreatePatient(patientForCreateDTO);

            return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] PatientForUpdateDTO patientForUpdateDTO)
        {
            _patientService.UpdatePatient(patientForUpdateDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _patientService.DeletePatient(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<PatientDTO> patientDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = patientDTOs.TotalCount,
                PageSize = patientDTOs.PageSize,
                CurrentPage = patientDTOs.CurrentPage,
                TotalPages = patientDTOs.TotalPages,
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
