using Finance.Models;
using System.Threading.Tasks;
using Finance.DTOs;
namespace Finance.Services{
    public interface IFinancaService{
        Task<IEnumerable<Financas>> ListarFinancas();
        Task<Financas?> BuscarPorId(int id);
        Task<Financas> CriarFinanca(CreateFinancaDTO request);
        Task AlterarFinanca(int id, CreateFinancaDTO request);
        Task RemoverFinanca(int id);
    }
}
