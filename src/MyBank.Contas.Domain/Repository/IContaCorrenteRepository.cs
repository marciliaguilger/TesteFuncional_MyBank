using MyBank.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Contas.Domain.Repository
{
    public interface IContaCorrenteRepository : IRepository<ContaCorrente>
    {
        void Atualizar(ContaCorrente conta);
        Task<ContaCorrente> ConsultarConta(string numeroConta);
    }
}
