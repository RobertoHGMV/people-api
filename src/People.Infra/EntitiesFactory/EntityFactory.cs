using People.Domain.Enums;
using People.Domain.Models;
using People.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace People.Infra.EntitiesFactory
{
    public class EntityFactory : IEntityFactory
    {
        public IList<State> CreateStates()
        {
            return new List<State>
            {
                new State((int)UfEnum.AC, "Acre"),
                new State((int)UfEnum.AL, "Alagoas"),
                new State((int)UfEnum.AM, "Amazonas"),
                new State((int)UfEnum.AP, "Amapá"),
                new State((int)UfEnum.BA, "Bahia"),
                new State((int)UfEnum.CE, "Ceará"),
                new State((int)UfEnum.DF, "Distrito Federal"),
                new State((int)UfEnum.ES, "Espirito Santo"),
                new State((int)UfEnum.GO, "Goiás"),
                new State((int)UfEnum.MA, "Maranhão"),
                new State((int)UfEnum.MG, "Minas Gerais"),
                new State((int)UfEnum.MS, "Mato Grosso do Sul"),
                new State((int)UfEnum.MT, "Mato Grosso"),
                new State((int)UfEnum.PA, "Pará"),
                new State((int)UfEnum.PB, "Paraiba"),
                new State((int)UfEnum.PE, "Pernambuco"),
                new State((int)UfEnum.PI, "Piauí"),
                new State((int)UfEnum.PR, "Paraná"),
                new State((int)UfEnum.RJ, "Rio de Janeiro"),
                new State((int)UfEnum.RN, "Rio Grande do Norte"),
                new State((int)UfEnum.RO, "Rondônia"),
                new State((int)UfEnum.RR, "Roraima"),
                new State((int)UfEnum.RS, "Rio Grande do Sul"),
                new State((int)UfEnum.SC, "Santa Catarina"),
                new State((int)UfEnum.SE, "Sergipe"),
                new State((int)UfEnum.SP, "São Paulo"),
                new State((int)UfEnum.TO, "Tocantis")
            };
        }

        public IList<Person> CreatePeople()
        {
            return new List<Person>
            {
                new Person("Marcus Fenix", new Cpf("186.314.630-00"), new DateTime(1982,03,06), (int)UfEnum.AP),
                new Person("Dominic Santiago", new Cpf("926.412.630-92"), new DateTime(1984,04,21), (int)UfEnum.MG),
                new Person("Augustus Cole", new Cpf("239.568.800-21"), new DateTime(1985,01,18), (int)UfEnum.PA),
                new Person("Damon Baird", new Cpf("208.407.310-35"), new DateTime(1987,07,15), (int)UfEnum.RR),
                new Person("Anya Stroud", new Cpf("031.855.260-40"), new DateTime(1989,01,06), (int)UfEnum.TO),
                new Person("Adam Fenix", new Cpf("409.882.080-32"), new DateTime(1970,03,20), (int)UfEnum.SP),
                new Person("Samantha Byrne", new Cpf("952.112.820-86"), new DateTime(1993,11,11), (int)UfEnum.AP),
                new Person("Sofia Hendrick", new Cpf("967.931.160-02"), new DateTime(1990,05,05), (int)UfEnum.ES)
            };
        }
    }
}
