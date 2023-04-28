using System.ComponentModel.DataAnnotations;

namespace Gst.Data.Dtos;

public class CreateProfissionalDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatório")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O CPF é obrigatório")]
    public string Cpf { get; set; }

    [Range(0, 100, ErrorMessage = "A comissão deve ser entre 0 e 100 porcento")]
    public decimal Comissao { get; set; }
}
