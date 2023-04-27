using Gst.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gst.Controllers;

[ApiController]
[Route("[controller]")]
public class ProfissionalController : ControllerBase
{
    List<Profissional> profissionais = new List<Profissional>();

    [HttpPost]
    public void AdicionarProfissional([FromBody] Profissional profissional)
    {
        profissionais.Add(profissional);
        Console.WriteLine(profissional.Nome);
        Console.WriteLine(profissional.Comissao);
        Console.WriteLine(profissional.DataNascimento);
    }
}
