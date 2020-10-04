using GraphQL;
using MyBank.WebApp.Api.Queries;

namespace MyBank.WebApp.Api.Schemas
{
    public class ContaCorrenteSchema : GraphQL.Types.Schema
    {
        public ContaCorrenteSchema(IDependencyResolver resolver)
            :base (resolver)
        {
            Query = resolver.Resolve<ContaCorrenteQuery>();
        }
    }
}
