using AutoMapper;
using Gst.Data;
using Gst.Data.Dtos.Ferramenta;
using Gst.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Gst.Controllers;

[ApiController]
[Route("[controller]")]
public class FerramentaController : ControllerBase
{
    private GstContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public FerramentaController(GstContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um ferramenta ao banco de dados
    /// </summary>
    /// <param name="ferramentaDto">Objeto com os campos necessários para criação de um ferramenta</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarFerramenta([FromBody] CreateFerramentaDto ferramentaDto)
    {
        Ferramenta ferramenta = _mapper.Map<Ferramenta>(ferramentaDto); 
        _context.Ferramentas.Add(ferramenta);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(RecuperarFerramentaPorId), 
            new { cdFerramenta = ferramenta.CdFerramenta }, 
            ferramenta);
    }

    [HttpGet]
    public IEnumerable<ReadFerramentaDto> RecuperarFerramentas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadFerramentaDto>>(_context.Ferramentas.Skip(skip).Take(take));
    }

    [HttpGet("{cdFerramenta}")]
    public IActionResult RecuperarFerramentaPorId(int cdFerramenta)
    {
        var ferramenta = _context.Ferramentas.FirstOrDefault(ferramenta => ferramenta.CdFerramenta == cdFerramenta);
        if (ferramenta == null) return NotFound();
        var ferramentaDto = _mapper.Map<ReadFerramentaDto>(ferramenta);
        return Ok(ferramentaDto);
    }

    [HttpPut("{cdFerramenta}")]
    public IActionResult AlterarFerramenta(int cdFerramenta, [FromBody] UpdateFerramentaDto ferramentaDto)
    {
        var ferramenta = _context.Ferramentas.FirstOrDefault(prof => prof.CdFerramenta == cdFerramenta);
        if (ferramenta == null) return NotFound();
        _mapper.Map(ferramentaDto, ferramenta);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{cdFerramenta}")]
    public IActionResult DeletarFerramenta(int cdFerramenta)
    {
        var ferramenta = _context.Ferramentas.FirstOrDefault(prof => prof.CdFerramenta == cdFerramenta);
        if (ferramenta == null) return NotFound();

        _context.Remove(ferramenta);
        _context.SaveChanges();
        return NoContent();
    }

}
