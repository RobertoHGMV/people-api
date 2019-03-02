using People.Domain.Enums;
using People.Domain.Models;
using System.Collections.Generic;

namespace People.Infra.Entities
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
    }
}
