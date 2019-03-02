using People.Domain.Models;
using People.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace People.Domain.Repositories
{
    public interface IPersonRepository
    {
        Person GetPersonByKey(Guid id);
        PersonListModel GetByKey(Guid id);
        IList<PersonListModel> GetByUf(int uf);
        IList<PersonListModel> GetAll();
        bool ExistsCpf(string cpfCode);
        void Add(Person person);
        void Update(Person person);
        void Delete(Person person);
    }
}
