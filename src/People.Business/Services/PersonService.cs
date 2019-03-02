using People.Common.Notifications;
using People.Domain.Models;
using People.Domain.Repositories;
using People.Domain.Services;
using People.Domain.ValueObjects;
using People.Domain.ViewModels;
using System;
using System.Collections.Generic;

namespace People.Business.Services
{
    public class PersonService : NotificationContext, IPersonService
    {
        IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public PersonListModel GetByKey(Guid id)
        {
            return _personRepository.GetByKey(id);
        }

        public IList<PersonListModel> GetByUf(int uf)
        {
            return _personRepository.GetByUf(uf);
        }

        public IList<PersonListModel> GetAll()
        {
            return _personRepository.GetAll();
        }

        public Person Add(PersonAddModel addModel)
        {
            var cpf = new Cpf(addModel.Cpf);
            var person = new Person(addModel.Name, cpf, addModel.DateBirth, addModel.Uf);

            ValidCpf(person);
            AddNotifications(person.Notifications);

            if (!HasNotifications)
                _personRepository.Add(person);

            return person;
        }

        public Person Update(Guid id, PersonEditModel editModel)
        {
            var person = _personRepository.GetPersonByKey(id);
            person.Update(editModel.Name, editModel.DateBirth, editModel.Uf);

            AddNotifications(person.Notifications);

            if (!HasNotifications)
                _personRepository.Update(person);

            return person;
        }

        public void Delete(Guid id)
        {
            var person = _personRepository.GetPersonByKey(id);
            _personRepository.Delete(person);
        }

        public PersonListModel CreatePersonListModel(Person person)
        {
            return new PersonListModel
            {
                Id = person.Id,
                Name = person.Name,
                Cpf = person.Cpf.Code,
                DateBirth = person.DateBirth,
                Uf = person.Uf
            };
        }

        private void ValidCpf(Person person)
        {
            if (_personRepository.ExistsCpf(person.Cpf.Code))
                person.AddNotification("CPF", "Já existe pessoa cadastrada com o cpf informado");
        }
    }
}
