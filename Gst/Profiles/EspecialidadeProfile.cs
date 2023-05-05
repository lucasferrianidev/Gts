using AutoMapper;
using Gst.Data.Dtos.Especialidade;
using Gst.Models;

namespace Gst.Profiles;

public class EspecialidadeProfile : Profile
{
    public EspecialidadeProfile()
    {
        CreateMap<CreateEspecialidadeDto, Especialidade>();
        CreateMap<UpdateEspecialidadeDto, Especialidade>();
        CreateMap<Especialidade, ReadEspecialidadeDto>();
    }
}
