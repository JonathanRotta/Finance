using Finance.DTOs;
using Finance.Models;
using Finance.Repositories;
using Finance.Services;
using Microsoft.AspNetCore.Mvc;


namespace Finance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase {

        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service) {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get() {

            return Ok(await _service.BuscarUsuarios());

        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Post(CreateUsuarioDTO usuario) {
            var resultado = await _service.CriarUsuario(usuario);
            if(resultado == null)
            {
                return BadRequest("Este e-mail ja está cadastrado");
            }
            return Ok(resultado);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, CreateUsuarioDTO request)
        {
            await _service.AlterarUsuario(id, request);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task Delete(int id) {
            await _service.RemoverUsuario(id);
            Console.WriteLine("usuario removido com sucesso");
        
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            var usuario = await _service.ValidarLogin(login);

            if (usuario == null)
            {
               
                return Unauthorized(new { message = "E-mail ou senha inválidos!" });
            }
      
            return Ok(new
            {
                usuario.Id,
                usuario.Nome,
                usuario.Email
            });

        }
    }
}
