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
        public ActionResult<IEnumerable<CustomerModel>> Get() {
            try {
                var customers = _customerService.Get();
                return Ok(customers);
            } catch (Exception e) {
                return StatusCode(500, new { Message = "Erro interno no servidor.", Details = e.Message });
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] CustomerCreateRequest customerCreateRequest) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {                
                CustomerModel customerModel = new CustomerModel() { 
                    Name = customerCreateRequest.Name,
                    Age = (int) customerCreateRequest.Age,
                    Phone = customerCreateRequest.Phone,
                    Email = customerCreateRequest.Email,
                };
                _customerService.Insert(customerModel);
                return Ok(new { Message = "Cliente inserido com sucesso." });

            } catch (Exception e) {
                return StatusCode(500, new { Message = "Erro interno no servidor.", Details = e.Message });
            }
        }

        [HttpPut]
        [Authorize]
        public ActionResult Put([FromBody] CustomerUpdateRequest customerUpdateRequest) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                CustomerModel customerModel = new CustomerModel() {
                    Id = (int) customerUpdateRequest.Id,
                    Name = customerUpdateRequest.Name,
                    Age = (int) customerUpdateRequest.Age,
                    Phone = customerUpdateRequest.Phone,
                    Email = customerUpdateRequest.Email,
                };
                _customerService.Update(customerModel);
                return Ok(new { Message = "Cliente atualizado com sucesso." });

            } catch (Exception e) {
                return StatusCode(500, new { Message = "Erro interno no servidor.", Details = e.Message });
            }
        }
    }
}
