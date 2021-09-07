﻿using Bogus;
using CL.Core.Domain;
using System;

namespace CL.FakeData.EnderecoData
{
    public class EnderecoViewFaker : Faker<Endereco>
    {
        public EnderecoViewFaker()
        {
            RuleFor(p => p.Numero, x => x.Address.BuildingNumber());
            RuleFor(p => p.CEP, x => Convert.ToInt32(x.Address.ZipCode().Replace("-", "")));
            RuleFor(p => p.Cidade, x => x.Address.City());
            RuleFor(p => p.Estado, x => x.PickRandom<Estado>());
            RuleFor(p => p.Logradouro, x => x.Address.StreetName());
            RuleFor(p => p.Complemento, x => x.Lorem.Sentence(20));
        }
    }
}