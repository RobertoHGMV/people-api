using People.Domain.Enums;
using People.Domain.Models;
using People.Infra.Entities;
using System.Collections.Generic;

namespace People.Infra.Context
{
    public class PersonDataContext : IPersonDataContext
    {
        public PersonDataContext(IEntityFactory entityFactory)
        {
            People = new List<Person>();
            States = entityFactory.CreateStates();
        }

        public IList<Person> People { get; set; }
        public IList<State> States { get; set; }
    }
}
