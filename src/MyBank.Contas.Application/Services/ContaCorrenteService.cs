using MyBank.Contas.Domain;
using MyBank.Contas.Domain.Application;
using MyBank.Contas.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyBank.Contas.Application.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<ContaCorrente> RealizarDeposito(string numeroConta, decimal valor)
        {
            var conta = await _contaCorrenteRepository.ConsultarConta(numeroConta);
            if (conta == null) throw new Exception("Conta não existe");

            conta.Depositar(valor);
            _contaCorrenteRepository.Atualizar(conta);
            
            if (await _contaCorrenteRepository.UnitOfWork.Commit())
            {
                return await ConsultarConta(numeroConta);
            }
            else
            {
                throw new Exception("Erro ao tentar realizar o deposito");
            }
        }

        public async Task<ContaCorrente> RealizarSaque(string numeroConta, decimal valor)
        {
            var conta = await _contaCorrenteRepository.ConsultarConta(numeroConta);

            if (conta == null) throw new Exception("Conta não existe");

            conta.Sacar(valor);
            _contaCorrenteRepository.Atualizar(conta);

            if (await _contaCorrenteRepository.UnitOfWork.Commit())
            {
                return await ConsultarConta(numeroConta);
            }
            else
            {
                throw new Exception("Saldo insuficiente.");
            }
        }
        public async Task<ContaCorrente> ConsultarConta(string numeroConta)
        {
            return await _contaCorrenteRepository.ConsultarConta(numeroConta);
        }

        public void Dispose()
        {
            _contaCorrenteRepository.Dispose();
        }
    }
}
