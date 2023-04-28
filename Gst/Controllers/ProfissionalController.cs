using AutoMapper;
using Gst.Data;
using Gst.Data.Dtos;
using Gst.Models;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public IActionResult AdicionarProfissional([FromBody] CreateProfissionalDto profissionalDto)
    {
        Profissional profissional = _mapper.Map<Profissional>(profissionalDto); 
        _context.Profissionais.Add(profissional);
        _context.SaveChanges();
        return CreatedAtAction(
            nameof(RecuperaProfissionalPorId), 
            new { cdProfissional = profissional.CdProfissional }, 
            profissional);
    }

    [HttpGet]
    public IEnumerable<Profissional> RecuperarProfissionais([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        return _context.Profissionais.Skip(skip).Take(take);
    }

    [HttpGet("{cdProfissional}")]
    public IActionResult RecuperaProfissionalPorId(int cdProfissional)
    {
        var profissional = _context.Profissionais.FirstOrDefault(profissional => profissional.CdProfissional == cdProfissional);
        if (profissional == null) return NotFound();
        return Ok(profissional);
    }
}
