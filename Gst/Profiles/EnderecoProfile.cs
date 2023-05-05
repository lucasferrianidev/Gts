using AutoMapper;
using Gst.Data.Dtos.Endereco;
using Gst.Models;

namespace Gst.Profiles;

public class EnderecoProfile : Profile
{
    public EnderecoProfile()
    {
        CreateMap<CreateEnderecoDto, Especialidade>();
        CreateMap<UpdateEnderecoDto, Especialidade>();
        CreateMap<Especialidade, ReadEnderecoDto>();
    }
}
