using GraphQL.Types;
using MyBank.Contas.Domain.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.WebApp.Api.Queries
{
    public class ContaCorrenteQuery : ObjectGraphType
    {
        public ContaCorrenteQuery(IContaCorrenteService contaCorrenteService)
        {
            Field<ContaCorrenteType>(
                "saldo",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "conta" }),
                resolve: service => contaCorrenteService.ConsultarConta(service.GetArgument<string>("conta")));
        }
    }
}
