using Finance.Data;
using Finance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;


namespace Finance.Repositories
{
    public class FinancaRepository
    {
        private readonly AppDbContext _context;

        public FinancaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Financas>> GetAllAsync()
        {
            return await _context.Financas.ToListAsync();
        }

        public async Task AddAsync(Financas financa)
        {
            await _context.Financas.AddAsync(financa);
            await _context.SaveChangesAsync();
        }
    }
}
