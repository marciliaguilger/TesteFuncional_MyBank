using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using MyBank.Contas.Application.Services;
using MyBank.Contas.Data;
using MyBank.Contas.Data.Repository;
using MyBank.Contas.Domain.Application;
using MyBank.Contas.Domain.Repository;
using MyBank.WebApp.Api.Queries;
using MyBank.WebApp.Api.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBank.WebApp.Api.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IContaCorrenteService, ContaCorrenteService>();

            //Repositories
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();

            //Context
            services.AddScoped<ContasContext>();

            //GraphQL
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<ContaCorrenteQuery>();
            services.AddSingleton<ContaCorrenteType>();

            //registro do ISchema  
            var sp = services.BuildServiceProvider();
            services.AddSingleton<ISchema>(new ContaCorrenteSchema(new FuncDependencyResolver(type => sp.GetService(type))));
        }
    }
}
