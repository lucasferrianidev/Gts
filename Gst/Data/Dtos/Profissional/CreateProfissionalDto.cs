using System.ComponentModel.DataAnnotations;

namespace Gst.Data.Dtos.Profissional;

public class CreateProfissionalDto
{
    public int CdEndereco { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
    public decimal Comissao { get; set; }
}
