using AutoMapper;
using CL.Core.Domain;
using CL.Core.Shared.ModelViews.Especialidade;
using CL.Core.Shared.ModelViews.Medico;

namespace CL.Manager.Mappings
{
    public class NovoMedicoMappingProfile : Profile
    {
        public NovoMedicoMappingProfile()
        {
            CreateMap<NovoMedico, Medico>();

            CreateMap<Medico, MedicoView>();

            CreateMap<AlteraMedico, Medico>();

            CreateMap<Especialidade, ReferenciaEspecialidade>()
                .ReverseMap();

            CreateMap<Especialidade, EspecialidadeView>()
                .ReverseMap();
        }
    }
}