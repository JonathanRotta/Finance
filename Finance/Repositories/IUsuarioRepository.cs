using Finance.Models;

namespace Finance.Repositories
{
    public interface IUsuarioRepository
    {
        Task AddAsync(Usuario usuario);

    }
}
