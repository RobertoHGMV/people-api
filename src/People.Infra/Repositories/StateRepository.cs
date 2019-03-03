using People.Domain.Models;
using People.Domain.Repositories;
using People.Infra.Context;
using System.Collections.Generic;

namespace People.Infra.Repositories
{
    public class StateRepository : IStateRepository
    {
        IPersonDataContext _personDataContext;

        public StateRepository(IPersonDataContext personDataContext)
        {
            _personDataContext = personDataContext;
        }

        public IList<State> GetAll()
        {
            return _personDataContext.States;
        }
    }
}
