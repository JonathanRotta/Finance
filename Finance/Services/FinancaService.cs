using Finance.DTOs;
using Finance.Models;
using Finance.Repositories;

namespace Finance.Services
{
    public class FinancaService
    {

        private readonly FinancaRepository _repository;

        public FinancaService(FinancaRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Financas>> ListarFinancas()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Financas> CriarFinanca(CreateFinancaRequest request)
        {
            
            var financa = new Financas
            {
                Valor = request.Valor,
                Descricao = request.Descricao.ToUpper(), 
                Categoria = request.Categoria,
                DataCriacao = DateTime.UtcNow
            };

            await _repository.AddAsync(financa);
            return financa;
        }

        public async Task RemoverFinanca(int id)
        {
          
            await _repository.DeleteAsync(id);
           
        }
    }
}
