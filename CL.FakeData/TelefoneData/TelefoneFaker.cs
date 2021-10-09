using Bogus;
using CL.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL.FakeData.TelefoneData
{
    public class TelefoneFaker : Faker<Telefone>
    {
        public TelefoneFaker(long clienteId)
        {
            RuleFor(o => o.ClienteId, f => clienteId);
            RuleFor(o => o.Numero, f => f.Person.Phone);
        }
    }
}