namespace Gst.Models;

public class Especialidade
{
    public int CdEspecialidade { get; set; }
    public string Nome { get; set; }
    public virtual ICollection<ProfissionalEspecialidade> ProfissionaisEspecialidades { get; set; }
}
