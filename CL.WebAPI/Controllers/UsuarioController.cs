using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Usuario;
using CL.Manager.Interfaces.Manager;
using Microsoft.AspNetCore.Authorization;
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
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Usuario usuario)
        {
            var usuarioLogado = await usuarioManager.ValidarUsuarioEGerarTokenAsync(usuario);

            if (usuarioLogado != null)
                return Ok(usuarioLogado);

            return Unauthorized();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var login = User.Identity.Name;
            var usuario = await usuarioManager.GetOneAsync(login);

            if (usuario == null)
                return BadRequest();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NovoUsuario novoUsuario)
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