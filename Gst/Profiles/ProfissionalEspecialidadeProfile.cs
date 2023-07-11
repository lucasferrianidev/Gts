using AutoMapper;
using Gst.Data.Dtos.Profissional;
using Gst.Models;

namespace Gst.Profiles;

public class ProfissionalEspecialidadeProfile : Profile
{
    public ProfissionalEspecialidadeProfile()
    {
        CreateMap<CreateProfissionalEspecialidadeDto, ProfissionalEspecialidade>();
        CreateMap<UpdateProfissionalEspecialidadeDto, ProfissionalEspecialidade>();
        CreateMap<ProfissionalEspecialidade, UpdateProfissionalEspecialidadeDto>();
        CreateMap<ProfissionalEspecialidade, ReadProfissionalEspecialidadeDto>();
    }
}
