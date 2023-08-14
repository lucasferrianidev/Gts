namespace GstAuth.Data.Dtos;

public class CreateUsuarioDto
{
    public string Username { get; set; }
    public string CPF { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Password { get; set; }
    public string RePassword { get; set; }
    public string Role { get; set; }
}
