using Gst.Data.Dtos.Endereco;
using Gst.Data.Dtos.Ferramenta;
using Gst.Models;


namespace Gst.Data.Dtos.Profissional;

public class ReadProfissionalDto
{
    public int CdProfissional { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
    public decimal Comissao { get; set; }
    public DateTime HoraDaConsulta { get; set; } = DateTime.Now;
    public virtual ReadEnderecoDto Endereco { get; set; }
    public virtual ICollection<ReadFerramentaDto> Ferramentas { get; set; }
    public virtual ICollection<ReadProfissionalEspecialidadeDto> ProfissionaisEspecialidades { get; set; }

}
