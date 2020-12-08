using Microsoft.EntityFrameworkCore;
using corridaFormula1.Models;

namespace corridaFormula1.Data
{
    public class corridaFormula1Context : DbContext
    {
        public corridaFormula1Context (DbContextOptions<corridaFormula1Context> options)
            : base(options)
        {
        }

        public DbSet<corrida> corrida { get; set; }
    }
}