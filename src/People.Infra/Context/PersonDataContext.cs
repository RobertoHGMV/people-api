using People.Domain.Models;
using People.Infra.EntitiesFactory;
using System.Collections.Generic;

namespace People.Infra.Context
{
    public class PersonDataContext : IPersonDataContext
    {
        public PersonDataContext(IEntityFactory entityFactory)
        {
            People = entityFactory.CreatePeople();
            States = entityFactory.CreateStates();
        }

        public IList<Person> People { get; set; }
        public IList<State> States { get; set; }
    }
}
