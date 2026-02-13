using Finance.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Finance.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task AddAsync(Usuario usuario);

        Task DeleteAsync(int id);

        Task<Usuario?> GetByEmailAsync(string email);

    }
}
