using MyBank.Core.DomainObjects;

namespace MyBank.Contas.Domain
{
    public class ContaCorrente: Entity
    {
        public string NumeroConta { get; private set; }
        public decimal Saldo { get; private set; }
        public ContaCorrente(string numeroConta, decimal saldo)
        {
            NumeroConta = numeroConta;
            Saldo = saldo;
        }

        internal bool PossuiSaldo(decimal valor) 
        {
            return Saldo >= valor;
        }

        public void Sacar(decimal valor)
        {
            if (valor < 0) valor *= -1;
            if (!PossuiSaldo(valor)) throw new DomainException("Saldo insuficiente");
            Saldo -= valor;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }
    }
}
