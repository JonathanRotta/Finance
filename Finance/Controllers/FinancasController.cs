using Finance.DTOs;
using Finance.Models;
using Finance.Repositories;
using Finance.Services;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancasController : ControllerBase
    {
        private readonly FinancaService _service;

        public FinancasController(FinancaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<Financas>>> Get()
        {
            return Ok(await _service.ListarFinancas());
        }

        [HttpPost]
        public async Task<ActionResult<Financas>> Post(CreateFinancaRequest request)
        {
            var resultado = await _service.CriarFinanca(request);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.RemoverFinanca(id);

            return NoContent();

        }
    }
}