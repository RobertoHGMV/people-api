using People.Domain.Models;
using System.Collections.Generic;

namespace People.Infra.Entities
{
    public interface IEntityFactory
    {
        IList<State> CreateStates();
    }
}
