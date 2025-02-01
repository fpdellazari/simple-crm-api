using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Domain.Entities;
using SimpleCRM.Domain.Models;
using SimpleCRM.Domain.Models.RequestModels;
using SimpleCRM.Domain.Services;

namespace SimpleCRM.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase {

        public readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService) {
            _customerService = customerService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult Get() {
            try {
                var customers = _customerService.Get();
                return Ok(customers);
            } catch (Exception e) {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<CustomerCreateRequest> Post([FromBody] CustomerCreateRequest customerCreateRequest) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                
                CustomerModel customerModel = new CustomerModel() { 
                    Name = customerCreateRequest.Name,
                    Age = customerCreateRequest.Age,
                    Phone = customerCreateRequest.Phone,
                    Email = customerCreateRequest.Email,
                };
                _customerService.Insert(customerModel);
                return Ok("Cliente inserido com sucesso.");

            } catch (Exception e) {
                return StatusCode(500, $"Erro interno: {e.Message}");
            }
        }
    }
}
