using People.Domain.Models;
using System.Collections.Generic;

namespace People.Domain.Repositories
{
    public interface IStateRepository
    {
        IList<State> GetAll();
    }
}
