using Finance.Data;
using Finance.Data;
using Finance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
namespace Finance.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context) {

            _context = context;
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

    }
}
