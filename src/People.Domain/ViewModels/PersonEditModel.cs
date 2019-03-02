using System;

namespace People.Domain.ViewModels
{
    public class PersonEditModel
    {
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }
        public int Uf { get; set; }
    }
}
