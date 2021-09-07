using Bogus;
using CL.Core.Domain;

namespace CL.FakeData.TelefoneData
{
    public class TelefoneViewFaker : Faker<Telefone>
    {
        public TelefoneViewFaker()
        {
            RuleFor(p => p.ClienteId, x => x.Random.Number(1, 10));
            RuleFor(p => p.Numero, x => x.Person.Phone);
        }
    }
}