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
            Field<ContaCorrenteType>(
                "sacar",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "conta" }, 
                                             new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "valor" }),
                resolve: service => contaCorrenteService.RealizarSaque(service.GetArgument<string>("conta"), service.GetArgument<decimal>("valor")));
            Field<ContaCorrenteType>(
                "depositar",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "conta" },
                                            new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "valor" }),
                resolve: service => contaCorrenteService.RealizarDeposito(service.GetArgument<string>("conta"), service.GetArgument<decimal>("valor")));
        }
    }
}
