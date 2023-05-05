using AutoMapper;
using Gst.Data.Dtos.Profissional;
using Gst.Models;

namespace Gst.Profiles;

public class ProfissionalProfile : Profile
{
    public ProfissionalProfile()
    {
        CreateMap<CreateProfissionalDto, Profissional>();
        CreateMap<UpdateProfissionalDto, Profissional>();
        CreateMap<Profissional, UpdateProfissionalDto>();
        CreateMap<Profissional, ReadProfissionalDto>();
    }
}
