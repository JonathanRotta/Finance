using Finance.DTOs;
using Finance.Models;
using Finance.Repositories;
using Finance.Services;
using Microsoft.AspNetCore.Mvc;


namespace Finance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }
        [HttpPost]

        public async Task<ActionResult<Usuario>> Post(CreateUsuarioDTO usuario)
        {
            var resultado = await _service.CriarUsuario(usuario);
            return Ok(resultado);
        }
        

        

    }
}
