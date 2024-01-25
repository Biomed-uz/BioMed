using BioMed.Domain.DTOs.Doctor;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    [Authorize]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorDTO>> GetDoctor(
            [FromQuery] DoctorResourceParameters doctorResourceParameters)
        {
            var doctor = _doctorService.GetDoctors(doctorResourceParameters);

            var metadate = GetPagenationMetaData(doctor);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadate));

            return Ok(doctor);
        }

        [HttpGet("{id}", Name = "GetDoctorById")]
        public ActionResult<DoctorDTO> Get(int id)
        {
            var doctor = _doctorService.GetDoctorById(id);

            return Ok(doctor);
        }

        [HttpPost]
        public ActionResult Post(DoctorForCreateDTO doctorForCreateDTO)
        {
            var doctor = _doctorService.CreateDoctor(doctorForCreateDTO);

            return CreatedAtAction(nameof(Get), new { id = doctor.Id }, doctor);
        }

        [HttpPut]
        public ActionResult Put(int id, [FromBody] DoctorForUpdateDTO doctorForUpdateDTO)
        {
            _doctorService.UpdateDoctor(doctorForUpdateDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _doctorService.DeleteDoctor(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<DoctorDTO> doctorDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = doctorDTOs.TotalCount,
                PageSize = doctorDTOs.PageSize,
                CurrentPage = doctorDTOs.CurrentPage,
                TotalPages = doctorDTOs.TotalPages,
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
