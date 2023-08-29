using AutoMapper;
using GstAuth.Data.Dtos;
using GstAuth.Models;
using GstAuth.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GstAuth.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CreateUsuarioAsync(CreateUsuarioDto dto)
    {
        await _usuarioService.CadastraAsync(dto);
        return Ok("Usuário cadastrado!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDto dto)
    {
        var accessToken = new AccessTokenDto();
        accessToken.AccessToken = await _usuarioService.Login(dto);
        return Ok(accessToken);
    }
}
