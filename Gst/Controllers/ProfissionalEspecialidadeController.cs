using AutoMapper;
using Gst.Data;
using Gst.Data.Dtos.Profissional;
using Gst.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Gst.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfissionalEspecialidadeController : ControllerBase
{
    private GstDbContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public ProfissionalEspecialidadeController(GstDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um profissionalEspecialidade ao banco de dados
    /// </summary>
    /// <param name="profissionalEspecialidadeDto">Objeto com os campos necessários para criação de um profissionalEspecialidade</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarProfissionalEspecialidade([FromBody] CreateProfissionalEspecialidadeDto profissionalEspecialidadeDto)
    {
        ProfissionalEspecialidade profissionalEspecialidade = _mapper.Map<ProfissionalEspecialidade>(profissionalEspecialidadeDto); 
        _context.ProfissionaisEspecialidades.Add(profissionalEspecialidade);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(RecuperarProfissionalEspecialidadePorId), 
            new { cdProfissionalEspecialidade = profissionalEspecialidade.CdProfissionalEspecialidade }, 
            profissionalEspecialidade);
    }

    [HttpGet]
    public IEnumerable<ReadProfissionalEspecialidadeDto> RecuperarProfissionais([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadProfissionalEspecialidadeDto>>(_context.ProfissionaisEspecialidades.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{cdProfissionalEspecialidade}")]
    public IActionResult RecuperarProfissionalEspecialidadePorId(int cdProfissionalEspecialidade)
    {
        var profissionalEspecialidade = _context.ProfissionaisEspecialidades.FirstOrDefault(profissionalEspecialidade => profissionalEspecialidade.CdProfissionalEspecialidade == cdProfissionalEspecialidade);
        if (profissionalEspecialidade == null) return NotFound();
        var profissionalEspecialidadeDto = _mapper.Map<ReadProfissionalEspecialidadeDto>(profissionalEspecialidade);
        return Ok(profissionalEspecialidadeDto);
    }

    [HttpPut("{cdProfissionalEspecialidade}")]
    public IActionResult AlterarProfissionalEspecialidade(int cdProfissionalEspecialidade, [FromBody] UpdateProfissionalEspecialidadeDto profissionalEspecialidadeDto)
    {
        var profissionalEspecialidade = _context.ProfissionaisEspecialidades.FirstOrDefault(prof => prof.CdProfissionalEspecialidade == cdProfissionalEspecialidade);
        if (profissionalEspecialidade == null) return NotFound();
        _mapper.Map(profissionalEspecialidadeDto, profissionalEspecialidade);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{cdProfissionalEspecialidade}")]
    public IActionResult AlterarProfissionalEspecialidadePatch(int cdProfissionalEspecialidade, JsonPatchDocument<UpdateProfissionalEspecialidadeDto> patch)
    {
        var profissionalEspecialidade = _context.ProfissionaisEspecialidades.FirstOrDefault(prof => prof.CdProfissionalEspecialidade == cdProfissionalEspecialidade);
        if (profissionalEspecialidade == null) return NotFound();

        var profissionalEspecialidadeToUpdate = _mapper.Map<UpdateProfissionalEspecialidadeDto>(profissionalEspecialidade);

        patch.ApplyTo(profissionalEspecialidadeToUpdate, ModelState);

        if (!TryValidateModel(profissionalEspecialidadeToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(profissionalEspecialidadeToUpdate, profissionalEspecialidade);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{cdProfissionalEspecialidade}")]
    public IActionResult DeletarProfissionalEspecialidade(int cdProfissionalEspecialidade)
    {
        var profissionalEspecialidade = _context.ProfissionaisEspecialidades.FirstOrDefault(prof => prof.CdProfissionalEspecialidade == cdProfissionalEspecialidade);
        if (profissionalEspecialidade == null) return NotFound();

        _context.Remove(profissionalEspecialidade);
        _context.SaveChanges();
        return NoContent();
    }

}
