using GraphQL.Types;
using MyBank.Contas.Domain;

namespace MyBank.WebApp.Api
{
    public class ContaCorrenteType : ObjectGraphType<ContaCorrente>
    {
        public ContaCorrenteType()
        {
            Field(x => x.NumeroConta);
            Field(x => x.Saldo);
        }
    }
}
