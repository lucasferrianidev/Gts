using System.ComponentModel.DataAnnotations;

namespace Gst.Data.Dtos.Profissional;

public class UpdateProfissionalDto
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
    public decimal Comissao { get; set; }
}
