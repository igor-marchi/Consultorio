﻿using Bogus;
using CL.Core.Shared.ModelViews.Cliente;
using CL.FakeData.EnderecoData;
using CL.FakeData.TelefoneData;

namespace CL.FakeData.ClienteData
{
    public class AlteraClienteFaker : Faker<AlteraCliente>
    {
        public AlteraClienteFaker()
        {
            var id = new Faker().Random.Number(1, 100);
            RuleFor(o => o.Id, f => id);
            RuleFor(o => o.Nome, f => f.Person.FullName);
            RuleFor(o => o.Genero, f => f.PickRandom<GeneroView>());
            RuleFor(o => o.Telefones, f => new NovoTelefoneFaker().Generate(3));
            RuleFor(o => o.Endereco, f => new NovoEnderecoFaker().Generate());
        }
    }
}