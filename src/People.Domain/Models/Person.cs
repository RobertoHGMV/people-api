using People.Common.Notifications;
using People.Common.Validations;
using People.Domain.Enums;
using People.Domain.ValueObjects;
using System;

namespace People.Domain.Models
{
    public class Person : NotificationContext
    {
        public Person(string name, Cpf cpf, DateTime dateBirth, int uf)
        {
            Id = Guid.NewGuid();
            Name = name;
            Cpf = cpf;
            DateBirth = dateBirth;
            Uf = uf;

            Validate();
        }

        #region Propriedades
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Cpf Cpf { get; private set; }
        public DateTime DateBirth { get; private set; }
        public int Uf { get; private set; }
        #endregion

        #region Métodos
        private void Validate()
        {
            const int minLength = 3;
            const int maxLength = 60;
            const int qtdStates = 27;
            
            AddNotifications(Cpf.Notifications);
            AddNotifications(new Validation()
                .HasMinLen(Name, minLength, "Name", $"Nome deve possuir de {minLength} à {maxLength} caracteres")
                .HasMaxLen(Name, maxLength, "Name", $"Nome deve possuir de {minLength} à {maxLength} caracteres")
                .IsInvalidValidDate(DateBirth, "DateBirth", "Data de aniversário inválida")
                .AreEquals(Uf, (int)UfEnum.None, "Uf", "UF não informado")
                .IsGreater(Uf, qtdStates, "Uf", "UF inválido").Notifications);
        }

        public void Update(string name, DateTime dateBirth, int uf)
        {
            Name = name;
            DateBirth = dateBirth;
            Uf = uf;

            Validate();
        }
        #endregion
    }
}
