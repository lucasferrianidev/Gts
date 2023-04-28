using AutoMapper;
using Gst.Data.Dtos;
using Gst.Models;

namespace Gst.Profiles;

public class ProfissionalProfile : Profile
{
    public ProfissionalProfile()
    {
        CreateMap<CreateProfissionalDto, Profissional>();
    }
}
