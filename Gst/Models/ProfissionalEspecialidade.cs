namespace Gst.Models;

public class ProfissionalEspecialidade
{
    public int CdProfissionalEspecialidade { get; set; }
    public int CdProfissional { get; set; }
    public int CdEspecialidade { get; set; }
    public virtual Profissional Profissional { get; set; }
    public virtual Especialidade Especialidade { get; set; }
}
