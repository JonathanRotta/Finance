using Finance.DTOs;
using Finance.Models;
using Finance.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Finance.Services
{
    public class FinancaService : IFinancaService
    {

        private readonly IFinancaRepository _repository;

        public FinancaService(IFinancaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Financas>> ListarFinancas()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Financas> BuscarPorId(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Financas> CriarFinanca(CreateFinancaDTO request)
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

        public async Task AlterarFinanca(int id, CreateFinancaDTO request)
        {
            var financaExistente = await _repository.GetByIdAsync(id);

            if (financaExistente != null)
            {
                financaExistente.Valor = request.Valor;
                financaExistente.Descricao = request.Descricao;
                financaExistente.Categoria = request.Categoria;
                financaExistente.DataCriacao = DateTime.UtcNow;

            }

            await _repository.UpdateAsync(financaExistente);

        }

        public async Task RemoverFinanca(int id)
        {
          
            await _repository.DeleteAsync(id);
           
        }
    }
}
