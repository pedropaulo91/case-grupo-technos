using System;
using System.Threading.Tasks;
using Case_Grupo_Technos.Helpers;
using Case_Grupo_Technos.Models;
using Case_Grupo_Technos.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Case_Grupo_Technos.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioService _service;
        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<ActionResult<Usuario>> CadastrarUsuario([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _service.CadastrarUsuario(usuario);
                return Ok(new { message = "Usuario cadastrado com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível cadastrar o usuário" });
            }
        }

        // Retorna o token JWT
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Autenticar([FromBody] Usuario usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Usuario usuarioAutenticado;

            try
            {
                usuarioAutenticado = await _service.AutenticarUsuario(usuario);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível autenticar o usuário" });
            }


            if (usuarioAutenticado == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = JwtAuth.GenerateToken(usuarioAutenticado);

            usuarioAutenticado.Senha = "";

            return new
            {
                usuario = usuarioAutenticado,
                token = token
            };

        }
    }
}