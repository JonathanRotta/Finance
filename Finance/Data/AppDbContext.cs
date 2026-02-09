using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Finance.Models;

namespace Finance.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        
        public DbSet<Financas> Financas { get; set; }

        
    }
}
