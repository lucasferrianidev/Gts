using AutoMapper;
using Gst.Data.Dtos.Endereco;
using Gst.Models;

namespace Gst.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        CreateMap<Endereco, ReadEnderecoDto>();
    }
}
