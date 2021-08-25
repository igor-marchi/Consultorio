﻿using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews;
using System;

namespace CL.Manager.Mappings
{
    public class NovoClienteMappingProfile : Profile
    {
        public NovoClienteMappingProfile()
        {
            CreateMap<NovoCliente, Cliente>()
                .ForMember(destino => destino.DataCriacao, options => options.MapFrom(origem => DateTime.Now))
                .ForMember(d => d.DataNascimento, op => op.MapFrom(or => or.DataNascimento.Date));
        }
    }
}