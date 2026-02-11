using Finance.Models;

namespace Finance.Repositories
{
    public interface IFinancaRepository
    {
        Task<IEnumerable<Financas>> GetAllAsync();
        Task<Financas?> GetByIdAsync(int id);
        Task AddAsync(Financas financa);
        Task UpdateAsync(Financas financa);
        Task DeleteAsync(int id);
    }
}
