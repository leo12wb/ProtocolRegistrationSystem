using Microsoft.AspNetCore.Mvc;
using ProtocolRegistrationSystem.Models;
using ProtocolRegistrationSystem.Services;
// using System;
// using System.Collections.Generic;

namespace ProtocolRegistrationSystem.Controllers
{
    [Route("api/protocols")]
    [ApiController]
    public class ProtocoloController : Controller
    {
        private readonly ProtocolService _service;

        public ProtocoloController()
        {
            _service = new ProtocolService();
        }

        // Métodos para Views
        [HttpGet("/protocol")]
        public IActionResult Index()
        {
            var protocols = _service.GetAll();
            return View(protocols);
        }

        [HttpGet("/protocol/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/protocol/create")]
        public IActionResult Create(Protocol protocol)
        {
            if (ModelState.IsValid)
            {
                protocol.InputDate = DateTime.Now;
                _service.Add(protocol);
                return RedirectToAction("Index");
            }
            return View(protocol);
        }

        // Métodos para API
        [HttpGet]
        public IActionResult GetProtocols()
        {
            var protocols = _service.GetAll();
            return Ok(protocols);
        }

        [HttpPost]
        public IActionResult CreateProtocol([FromBody] Protocol protocol)
        {
            if (protocol == null)
                return BadRequest("Dados inválidos.");

            protocol.InputDate = DateTime.Now;
            _service.Add(protocol);
            return CreatedAtAction(nameof(GetProtocols), new { id = protocol.Id }, protocol);
        }
    }
}
