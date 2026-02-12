using Finance.Models;
using System.Threading.Tasks;

namespace Finance.Repositories
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);

        Task DeleteAsync(int id);

        Task<Usuario?> GetByEmailAsync(string email);

    }
}
