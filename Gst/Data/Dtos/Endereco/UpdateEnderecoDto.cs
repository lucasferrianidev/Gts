using System.ComponentModel.DataAnnotations;

namespace Gst.Data.Dtos.Endereco;

public class UpdateEnderecoDto
{
    [Required]
    [StringLength(150)]
    public string Logradouro { get; set; }

    [Required]
    [StringLength(10)]
    public string Numero { get; set; }

    [StringLength(100)]
    public string Complemento { get; set; }

    [Required]
    [StringLength(100)]
    public string Bairro { get; set; }

    [Required]
    [StringLength(8)]
    public string Cep { get; set; }

    [Required]
    [StringLength(150)]
    public string Cidade { get; set; }

    [Required]
    [StringLength(2)]
    public string Uf { get; set; }

}
