using People.Domain.Models;
using People.Domain.Repositories;
using People.Domain.ViewModels;
using People.Infra.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace People.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        IPersonDataContext _personDataContext;

        public PersonRepository(IPersonDataContext personDataContext)
        {
            _personDataContext = personDataContext;
        }

        public Person GetPersonByKey(Guid id)
        {
            return _personDataContext.People.FirstOrDefault(c => c.Id == id);
        }

        public PersonListModel GetByKey(Guid id)
        {
            return _personDataContext.People.Where(c => c.Id == id)
                .Join(_personDataContext.States,
                person => person.Uf,
                state => state.Id,
                (person, state) => new PersonListModel
                {
                    Id = person.Id,
                    Name = person.Name,
                    Cpf = person.Cpf.Code,
                    DateBirth = person.DateBirth,
                    Uf = state.Id,
                    UfDescription = state.Description
                }).FirstOrDefault();
        }

        public IList<PersonListModel> GetByUf(int uf)
        {
            return _personDataContext.People.Where(c => c.Uf == uf)
                .Join(_personDataContext.States,
                person => person.Uf,
                state => state.Id,
                (person, state) => new PersonListModel
                {
                    Id = person.Id,
                    Name = person.Name,
                    Cpf = person.Cpf.Code,
                    DateBirth = person.DateBirth,
                    Uf = state.Id,
                    UfDescription = state.Description
                }).ToList();
        }

        public IList<PersonListModel> GetAll()
        {
            return _personDataContext.People
                .Join(_personDataContext.States,
                person => person.Uf,
                state => state.Id,
                (person, state) => new PersonListModel
                {
                    Id = person.Id,
                    Name = person.Name,
                    Cpf = person.Cpf.Code,
                    DateBirth = person.DateBirth,
                    Uf = state.Id,
                    UfDescription = state.Description
                }).ToList();
        }

        public bool ExistsCpf(string cpfCode)
        {
            return _personDataContext.People.Any(c => cpfCode == c.Cpf.Code);
        }

        public void Add(Person person)
        {
            _personDataContext.People.Add(person);
        }

        public void Update(Person person)
        {
            var personTemp = _personDataContext.People.FirstOrDefault(c => c.Id == person.Id);
            personTemp?.Update(person.Name, person.DateBirth, person.Uf);
        }

        public void Delete(Person person)
        {
            _personDataContext.People.Remove(person);
        }
    }
}
