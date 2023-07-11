using System.ComponentModel.DataAnnotations;

namespace Gst.Data.Dtos.Profissional;

public class UpdateProfissionalEspecialidadeDto
{
    public int CdProfissional { get; set; }
    public int CdEspecialidade { get; set; }
}
