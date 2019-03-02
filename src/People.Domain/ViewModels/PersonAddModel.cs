using System;

namespace People.Domain.ViewModels
{
    public class PersonAddModel
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public DateTime DateBirth { get; set; }
        public int Uf { get; set; }
    }
}
