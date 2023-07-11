using AutoMapper;
using Gst.Data;
using Gst.Data.Dtos.Especialidade;
using Microsoft.AspNetCore.Mvc;
using Gst.Models;

namespace Gst.Controllers;

[ApiController]
[Route("[controller]")]
public class EspecialidadeController : ControllerBase
{
    private GstDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public EspecialidadeController(GstDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um especilidade ao banco de dados
    /// </summary>
    /// <param name="especilidadeDto">Objeto com os campos necessários para criação de um especilidade</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarEspecialidade([FromBody] CreateEspecialidadeDto especilidadeDto)
    {
        Especialidade especilidade = _mapper.Map<Especialidade>(especilidadeDto); 
        _context.Especialidades.Add(especilidade);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(RecuperarEspecialidadePorId), 
            new { cdEspecialidade = especilidade.CdEspecialidade }, 
            especilidade);
    }

    [HttpGet]
    public IEnumerable<ReadEspecialidadeDto> RecuperarEspecialidades([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadEspecialidadeDto>>(_context.Especialidades.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{cdEspecialidade}")]
    public IActionResult RecuperarEspecialidadePorId(int cdEspecialidade)
    {
        var especilidade = _context.Especialidades.FirstOrDefault(especilidade => especilidade.CdEspecialidade == cdEspecialidade);
        if (especilidade == null) return NotFound();
        var especilidadeDto = _mapper.Map<ReadEspecialidadeDto>(especilidade);
        return Ok(especilidadeDto);
    }

    [HttpPut("{cdEspecialidade}")]
    public IActionResult AlterarEspecialidade(int cdEspecialidade, [FromBody] UpdateEspecialidadeDto especilidadeDto)
    {
        var especilidade = _context.Especialidades.FirstOrDefault(prof => prof.CdEspecialidade == cdEspecialidade);
        if (especilidade == null) return NotFound();
        _mapper.Map(especilidadeDto, especilidade);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{cdEspecialidade}")]
    public IActionResult DeletarEspecialidade(int cdEspecialidade)
    {
        var especilidade = _context.Especialidades.FirstOrDefault(prof => prof.CdEspecialidade == cdEspecialidade);
        if (especilidade == null) return NotFound();

        _context.Remove(especilidade);
        _context.SaveChanges();
        return NoContent();
    }

}
