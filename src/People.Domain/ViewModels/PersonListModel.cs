using System;

namespace People.Domain.ViewModels
{
    public class PersonListModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime DateBirth { get; set; }
        public int Uf { get; set; }
        public string UfDescription { get; set; }
    }
}
