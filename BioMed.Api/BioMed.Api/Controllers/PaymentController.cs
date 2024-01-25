using BioMed.Domain.DTOs.Payment;
using BioMed.Domain.Interfaces.Services;
using BioMed.Domain.Pagination;
using BioMed.Domain.ResourceParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BioMed.Api.Controllers
{
    [Route("api/payment")]
    [ApiController]
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PaymentDTO>> GetPayment(
            [FromQuery] PaymentResourceParameters paymentResourceParameters)
        {
            var payment = _paymentService.GetPayments(paymentResourceParameters);

            var metadata = GetPagenationMetaData(payment);

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(payment);
        }

        [HttpGet("{id}", Name = "GetPaymentById")]
        public ActionResult<PaymentDTO> Get(int id)
        {
            var payment = _paymentService.GetPaymentById(id);

            return Ok(payment);
        }

        [HttpPost]
        public ActionResult<PaymentDTO> Post(PaymentForCreateDTO paymentForCreateDTO)
        {
            var payment = _paymentService.CreatePayment(paymentForCreateDTO);

            return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
        }

        [HttpPut]   
        public ActionResult Put(PaymentForUpdateDTO paymentForUpdateDTO)
        {
            _paymentService.UpdatePayment(paymentForUpdateDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _paymentService.DeletePayment(id);

            return NoContent();
        }

        private PagenationMetaData GetPagenationMetaData(PaginatedList<PaymentDTO> paymentDTOs)
        {
            return new PagenationMetaData
            {
                Totalcount = paymentDTOs.TotalCount,
                PageSize = paymentDTOs.PageSize,
                CurrentPage = paymentDTOs.CurrentPage,
                TotalPages = paymentDTOs.TotalPages,
            };
        }
    }
}
