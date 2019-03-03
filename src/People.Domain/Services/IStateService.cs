using People.Domain.Models;
using System.Collections.Generic;

namespace People.Domain.Services
{
    public interface IStateService
    {
        IList<State> GetAll();
    }
}
