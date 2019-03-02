using People.Domain.Models;
using System.Collections.Generic;

namespace People.Infra.Context
{
    public interface IPersonDataContext
    {
        IList<Person> People { get; set; }
        IList<State> States { get; set; }
    }
}
