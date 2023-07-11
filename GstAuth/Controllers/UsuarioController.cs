using AutoMapper;
using GstAuth.Data.Dtos.Usuario;
using GstAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GstAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private IMapper _mapper { get; set; }

    private UserManager<Usuario> _userManager;

    public UsuarioController(IMapper mapper, UserManager<Usuario> userManager)
    {
        _mapper = mapper;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUsuario(CreateUsuarioDto dto)
    {
        var usuario = _mapper.Map<Usuario>(dto);

        var resultado = await _userManager.CreateAsync(usuario, dto.Password);

        if (resultado.Succeeded)
        {
            return Ok(resultado);
        }

        throw new ApplicationException("Falha ao cadastrar usuário!");
    }
}
