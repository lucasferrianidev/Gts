using System.ComponentModel.DataAnnotations;

namespace Gst.Data.Dtos.Ferramenta;

public class UpdateFerramentaDto
{
    [Required(ErrorMessage = "Nome da ferramenta é obrigatório")]
    public string Nome { get; set; }
    public string Marca { get; set; }
}
