﻿using AutoMapper;
using GstAuth.Data.Dtos;
using GstAuth.Models;

namespace GstAuth.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDto, Usuario>();
    }
}
