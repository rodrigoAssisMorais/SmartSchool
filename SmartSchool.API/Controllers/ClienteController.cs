using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Business;
using SmartSchool.API.Data;
using SmartSchool.API.Models;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _repo;
        private readonly IClienteBusiness _business;

        public ClienteController(IClienteRepository repo, IClienteBusiness business)
        {
            _repo = repo;
            _business = business;
        }

        [HttpPost]
        public IActionResult Post(ClienteModel cliente)
        {

            var result = _business.Add(cliente);
            if (result.Success)            
                return Ok(result.Resource);

            return BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Cliente cliente)
        {
            var result = _business.Update(cliente);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {

            var result = _business.Delete(id);

            if (result.Success)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _business.GetClienteById(id);
            ClienteModel cliente = (ClienteModel)result.Resource;
            if (cliente == null) return BadRequest("Cliente não encontrado!");
            return Ok(cliente);
        }

        [HttpGet]
        public IActionResult Get()
        {

            var result = _business.GetAllClientes();

            if (result.Success)
                return Ok((result.Resource as List<ClienteModel>).ToArray());

            return BadRequest(result.Message);

        }
    }

}
