using Microsoft.EntityFrameworkCore;
using MyBank.Contas.Domain;
using MyBank.Contas.Domain.Repository;
using MyBank.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Contas.Data.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly ContasContext _context;

        public ContaCorrenteRepository(ContasContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<ContaCorrente> ConsultarConta(string numeroConta)
        {
            return await _context.Contas.FirstOrDefaultAsync(p => p.NumeroConta == numeroConta);
        }
        
        public void Atualizar(ContaCorrente conta)
        {
            _context.Contas.Update(conta);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

    }
}
