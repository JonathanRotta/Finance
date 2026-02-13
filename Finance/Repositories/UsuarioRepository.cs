using Finance.Data;
using Finance.Data;
using Finance.DTOs;
using Finance.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _context.Usuario.ToListAsync();
            
        }

        public async Task<Usuario> GetByIdAsync(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }

        public async Task AddAsync(Usuario usuario){
            await _context.Usuario.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
        
        }
            

         

        public async Task DeleteAsync(int id)
        {
            var removido = await _context.Usuario.FindAsync(id);

            if (removido != null) {
                _context.Usuario.Remove(removido);
                await _context.SaveChangesAsync();

            }

        }

        public async Task<Usuario?> GetByEmailAsync(string email) { 
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email); 
        }
    }
}
