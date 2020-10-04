using Microsoft.EntityFrameworkCore;
using MyBank.Core.Data;
using System.Threading.Tasks;
using MyBank.Contas.Domain;

namespace MyBank.Contas.Data
{
    public class ContasContext : DbContext, IUnitOfWork
    {
        public ContasContext(DbContextOptions<ContasContext> options)
            : base (options) { }

        public DbSet<ContaCorrente> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContasContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
