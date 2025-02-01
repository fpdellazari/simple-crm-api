using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Domain.Models;
using SimpleCRM.Domain.Models.RequestModels;
using SimpleCRM.Domain.Services;

namespace SimpleCRM.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase {

        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService) {
            _saleService = saleService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<SaleModel>> Get() {
            try {
                var sales = _saleService.Get();
                return Ok(sales);
            } catch (Exception e) {
                return StatusCode(500, $"Erro interno: {e.Message}");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] SaleCreateRequest saleCreateRequest) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                SaleModel saleModel = new SaleModel() {
                    CustomerId = saleCreateRequest.CustomerId,
                    ProductId = saleCreateRequest.ProductId,
                    Quantity = saleCreateRequest.Quantity
                };

                _saleService.Insert(saleModel);
                return Ok("Venda registrada com sucesso.");
            } catch (Exception e) {
                return StatusCode(500, $"Erro interno: {e.Message}");
            }
        }
    }
}
