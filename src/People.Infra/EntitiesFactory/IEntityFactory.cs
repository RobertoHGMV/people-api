using People.Domain.Models;
using System.Collections.Generic;

namespace People.Infra.EntitiesFactory
{
    public interface IEntityFactory
    {
        IList<Person> CreatePeople();
        IList<State> CreateStates();
    }
}
