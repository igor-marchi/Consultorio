using CL.Core.Domain;
using CL.Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CL.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioManager usuarioManager;

        public UsuarioController(IUsuarioManager usuarioManager)
        {
            this.usuarioManager = usuarioManager;
        }

        [HttpGet]
        [Route("ValidaUsuario")]
        public async Task<IActionResult> ValidarUsuario([FromBody] Usuario usuario)
        {
            var valido = await usuarioManager.ValidaSenhaAsync(usuario);

            if (valido)
                return Ok();

            return Unauthorized();
        }

        [HttpGet]
        [Route("user/{login}")]
        public async Task<IActionResult> Get([FromBody] string login)
        {
            var usuario = await usuarioManager.GetOneAsync(login);

            if (usuario == null)
                return BadRequest();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Usuario novoUsuario)
        {
            var usuarioCriado = await usuarioManager.InsertAsync(novoUsuario);

            return CreatedAtAction(nameof(Get), new { login = usuarioCriado.Login }, usuarioCriado);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Usuario novoUsuario)
        {
            var usuarioAlterado = await usuarioManager.UpdateUsuarioAsync(novoUsuario);

            return Ok(usuarioAlterado);
        }
    }
}