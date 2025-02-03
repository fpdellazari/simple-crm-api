using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Domain.Services;
using SimpleCRM.Domain.Services.Reports;

namespace SimpleCRM.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase {

        public readonly IDashboardsService _dashboardsService;

        public DashboardController(IDashboardsService dashboardsService) {
            _dashboardsService = dashboardsService;        
        }

        [HttpGet]
        [Authorize]
        public ActionResult Get() {
            try {
                var overviewReport = _dashboardsService.Get();
                return Ok(overviewReport);

            } catch (Exception e) {
                return StatusCode(500, new { Message = "Erro interno no servidor.", Details = e.Message });
            }
        }
    }
}
