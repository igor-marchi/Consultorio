using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Cliente;
using System;

namespace CL.Manager.Mappings
{
    public class AlteraClienteMappingProfile : Profile
    {
        public AlteraClienteMappingProfile()
        {
            CreateMap<AlteraCliente, Cliente>()
               .ForMember(destino => destino.UltimaAtualizacao, options => options.MapFrom(origem => DateTime.Now))
               .ForMember(d => d.DataNascimento, op => op.MapFrom(or => or.DataNascimento.Date));
        }
    }
}