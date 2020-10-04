using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Contas.Domain.Application
{
    public interface IContaCorrenteService : IDisposable
    {
        Task<ContaCorrente> RealizarSaque(string numeroConta, decimal valor);
        Task<ContaCorrente> RealizarDeposito(string numeroConta, decimal valor);
        Task<ContaCorrente> ConsultarConta(string numeroConta);

    }
}
