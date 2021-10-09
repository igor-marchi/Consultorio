using Bogus;
using Bogus.Extensions.Brazil;
using CL.Core.Domain;
using CL.FakeData.EnderecoData;
using CL.FakeData.TelefoneData;

namespace CL.FakeData.ClienteData
{
    public class ClienteFaker : Faker<Cliente>
    {
        public ClienteFaker()
        {
            var id = new Faker().Random.Number(1, 999999);
            RuleFor(entity => entity.Id, faker => id);
            RuleFor(e => e.Nome, f => f.Person.FullName);
            RuleFor(e => e.Genero, f => f.PickRandom<Genero>());
            RuleFor(e => e.Documento, f => f.Person.Cpf());
            RuleFor(e => e.DataCriacao, f => f.Date.Past());
            RuleFor(e => e.UltimaAtualizacao, f => f.Date.Past());
            RuleFor(e => e.Telefones, f => new TelefoneFaker(id).Generate(3));
            RuleFor(e => e.Endereco, f => new EnderecoFaker(id).Generate());
        }
    }
}