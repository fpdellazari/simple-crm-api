﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleCRM.Application.Services;
using SimpleCRM.Domain.Models.RequestModels;
using SimpleCRM.Domain.Models;
using SimpleCRM.Domain.Services;
using SimpleCRM.Domain.Entities;

namespace SimpleCRM.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class ContactHistoryController : ControllerBase {

        public readonly IContactHistoryService _contactHistoryService;

        public ContactHistoryController(IContactHistoryService contactHistoryService) {
            _contactHistoryService = contactHistoryService;
        }

        [HttpGet]
        //[ApiKey]
        [Authorize]
        public ActionResult Get() {
            try {
                var contactHistories = _contactHistoryService.Get();
                return Ok(contactHistories);
            } catch (Exception e) {
                return StatusCode(500, $"Erro interno: {e.Message}");
            }
        }

        [HttpPost]
        [Authorize]
        public ActionResult<string> Post([FromBody] ContactHistoryCreateRequest contactHistoryCreateRequest) {

            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }

            try {
                ContactHistoryModel contactHistoryModel = new ContactHistoryModel() {
                    CustomerId = (int) contactHistoryCreateRequest.CustomerId,
                    Type = (Domain.Enums.ContactType) contactHistoryCreateRequest.Type,
                    Notes = contactHistoryCreateRequest.Notes
                };
                _contactHistoryService.Insert(contactHistoryModel);
                return Ok("Histórico de contato inserido com sucesso.");

            } catch (Exception e) {
                return StatusCode(500, $"Erro interno: {e.Message}");
            }
        }

    }
}
