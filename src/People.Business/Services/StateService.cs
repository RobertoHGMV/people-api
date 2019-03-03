using People.Domain.Models;
using People.Domain.Repositories;
using People.Domain.Services;
using System.Collections.Generic;

namespace People.Business.Services
{
    public class StateService : IStateService
    {
        IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public IList<State> GetAll()
        {
            return _stateRepository.GetAll();
        }
    }
}
