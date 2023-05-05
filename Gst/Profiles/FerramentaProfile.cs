using AutoMapper;
using Gst.Data.Dtos.Ferramenta;
using Gst.Models;

namespace Gst.Profiles;

public class FerramentaProfile : Profile
{
    public FerramentaProfile()
    {
        CreateMap<CreateFerramentaDto, Ferramenta>();
        CreateMap<UpdateFerramentaDto, Ferramenta>();
        CreateMap<Ferramenta, UpdateFerramentaDto>();
        CreateMap<Ferramenta, ReadFerramentaDto>();
    }
}
