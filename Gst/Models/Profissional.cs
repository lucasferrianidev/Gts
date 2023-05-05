namespace Gst.Models;

public class Profissional
{
    public int CdProfissional { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Cpf { get; set; }
    public decimal Comissao { get; set; }
    public int CdEndereco { get; set; }
    public virtual Endereco Endereco { get; set; }
    public virtual ICollection<Ferramenta> Ferramentas { get; set; }
}
