using Microsoft.Extensions.DependencyInjection;
using People.Business.Services;
using People.Domain.Repositories;
using People.Domain.Services;
using People.Infra.Context;
using People.Infra.Entities;
using People.Infra.Repositories;

namespace People.DependencyInjection
{
    public class DependencyResolver
    {
        public void Resolver(IServiceCollection services)
        {
            services.AddSingleton<IPersonDataContext, PersonDataContext>();
            services.AddTransient<IEntityFactory, EntityFactory>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonService, PersonService>();
        }
    }
}
