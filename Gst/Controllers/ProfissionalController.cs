using AutoMapper;
using Gst.Data;
using Gst.Data.Dtos.Profissional;
using Gst.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gst.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfissionalController : ControllerBase
{
    private GstContext _context { get; set; }
    private IMapper _mapper { get; set; }

    public ProfissionalController(GstContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona um profissional ao banco de dados
    /// </summary>
    /// <param name="profissionalDto">Objeto com os campos necessários para criação de um profissional</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionarProfissional([FromBody] CreateProfissionalDto profissionalDto)
    {
        Profissional profissional = _mapper.Map<Profissional>(profissionalDto); 
        _context.Profissionais.Add(profissional);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(RecuperarProfissionalPorId), 
            new { cdProfissional = profissional.CdProfissional }, 
            profissional);
    }

    [HttpGet]
    public IEnumerable<ReadProfissionalDto> RecuperarProfissionais([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _mapper.Map<List<ReadProfissionalDto>>(_context.Profissionais.Skip(skip).Take(take).ToList());
    }

    [HttpGet("{cdProfissional}")]
    public IActionResult RecuperarProfissionalPorId(int cdProfissional)
    {
        var profissional = _context.Profissionais.FirstOrDefault(profissional => profissional.CdProfissional == cdProfissional);
        if (profissional == null) return NotFound();
        var profissionalDto = _mapper.Map<ReadProfissionalDto>(profissional);
        return Ok(profissionalDto);
    }

    [HttpPut("{cdProfissional}")]
    public IActionResult AlterarProfissional(int cdProfissional, [FromBody] UpdateProfissionalDto profissionalDto)
    {
        var profissional = _context.Profissionais.FirstOrDefault(prof => prof.CdProfissional == cdProfissional);
        if (profissional == null) return NotFound();
        _mapper.Map(profissionalDto, profissional);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{cdProfissional}")]
    public IActionResult AlterarProfissionalPatch(int cdProfissional, JsonPatchDocument<UpdateProfissionalDto> patch)
    {
        var profissional = _context.Profissionais.FirstOrDefault(prof => prof.CdProfissional == cdProfissional);
        if (profissional == null) return NotFound();

        var profissionalToUpdate = _mapper.Map<UpdateProfissionalDto>(profissional);

        patch.ApplyTo(profissionalToUpdate, ModelState);

        if (!TryValidateModel(profissionalToUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(profissionalToUpdate, profissional);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{cdProfissional}")]
    public IActionResult DeletarProfissional(int cdProfissional)
    {
        var profissional = _context.Profissionais.FirstOrDefault(prof => prof.CdProfissional == cdProfissional);
        if (profissional == null) return NotFound();

        _context.Remove(profissional);
        _context.SaveChanges();
        return NoContent();
    }

}
