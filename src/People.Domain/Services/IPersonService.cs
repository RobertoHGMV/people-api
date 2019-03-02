using People.Domain.Models;
using People.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace People.Domain.Services
{
    public interface IPersonService
    {
        PersonListModel GetByKey(Guid id);
        IList<PersonListModel> GetByUf(int uf);
        IList<PersonListModel> GetAll();
        Person Add(PersonAddModel addModel);
        Person Update(Guid id, PersonEditModel editModel);
        void Delete(Guid id);
        PersonListModel CreatePersonListModel(Person person);
    }
}
