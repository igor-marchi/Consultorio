using CL.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var list = new List<Cliente>
            {
                new Cliente
                {
                    Id = 1,
                    Name = "Claudio",
                    BirthDate = new DateTime(1980,01,15)
                },
                new Cliente
                {
                    Id = 2,
                    Name = "Sergio",
                    BirthDate = new DateTime(1970,12,25)
                }
            };

            return Ok(list);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}