using AutoMapper;
using Gst.Data;
using Gst.Data.Dtos.Endereco;
using Gst.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gst.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private GstContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public EnderecoController(GstContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um endereco ao banco de dados
    /// </summary>
    /// <param name="enderecoDto">Objeto com os campos necessários para criação de um endereco</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = _mapper.Map<Endereco>(enderecoDto); 
        _context.Enderecos.Add(endereco);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(RecuperarEnderecoPorId), 
            new { cdEndereco = endereco.CdEndereco }, 
            endereco);
    }

    [HttpGet]
    public IEnumerable<ReadEnderecoDto> RecuperarEnderecos([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadEnderecoDto>>(_context.Enderecos.Skip(skip).Take(take));
    }

    [HttpGet("{cdEndereco}")]
    public IActionResult RecuperarEnderecoPorId(int cdEndereco)
    {
        var endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.CdEndereco == cdEndereco);
        if (endereco == null) return NotFound();
        var enderecoDto = _mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    [HttpPut("{cdEndereco}")]
    public IActionResult AlterarEndereco(int cdEndereco, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = _context.Enderecos.FirstOrDefault(prof => prof.CdEndereco == cdEndereco);
        if (endereco == null) return NotFound();
        _mapper.Map(enderecoDto, endereco);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{cdEndereco}")]
    public IActionResult DeletarEndereco(int cdEndereco)
    {
        var endereco = _context.Enderecos.FirstOrDefault(prof => prof.CdEndereco == cdEndereco);
        if (endereco == null) return NotFound();

        _context.Remove(endereco);
        _context.SaveChanges();
        return NoContent();
    }

}
