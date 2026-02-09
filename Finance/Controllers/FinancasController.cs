using Finance.DTOs;
using Finance.Models;
using Finance.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancasController : ControllerBase
    {
        private readonly FinancaRepository _repository;

        public FinancasController(FinancaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Financas>>> Get() 
        {
            var financas = await _repository.GetAllAsync();
            return Ok(financas);
        }

        [HttpPost]
        public async Task<ActionResult<Financas>> Post(CreateFinancaRequest request) 
        {
            var financa = new Financas
            {
                Valor = request.Valor,
                Descricao = request.Descricao,
                Categoria = request.Categoria,
                DataCriacao = DateTime.UtcNow
            };

            await _repository.AddAsync(financa);

            return Ok(financa);
        }
    }
}